// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Net;
using System.Net.Http.Headers;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Blobs;
using MicroBlogger.Application.Common.Interfaces;
using MicroBlogger.Domain.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Paychoice.Service.Schedular;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Webp;
using Microsoft.Identity.Client;
using Microsoft.AspNetCore.Hosting.Server;
using Google.Apis.Discovery;
using Microsoft.AspNetCore.Hosting.Server.Features;
using MicroBlogger.Infrastructure.Services;
using System.Reflection.Metadata;

namespace MicroBlogger.Api.Workers;

public class WebpFileConversionHostService : ScheduleTask
{

    private readonly ILogger<WebpFileConversionHostService> _logger;
    private const string ServiceName = "WebpFileConversion";
    private IApplicationDbContext _context;
    private bool IsBusy;
    private readonly IConfiguration _configuration;
    private readonly IServer _server;
    private readonly IServiceProvider _serviceProvider;
    public WebpFileConversionHostService(ILogger<WebpFileConversionHostService> logger, IOptions<ScheduleOptions> options, IConfiguration configuration, IServer server, IServiceProvider serviceProvider) : base(options.Value.AmexServiceSchedule)
    {
        _logger = logger;
        _configuration = configuration;
        _server = server;
        _serviceProvider = serviceProvider;



    }
    protected override async Task Process()
    {
        try
        {
            _logger.LogInformation($"{ServiceName} Started at {DateTimeOffset.Now}");

            await WebpFileConversion();

            _logger.LogInformation($"{ServiceName}  last-updated on {DateTimeOffset.Now}");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, $"Failed to complete {ServiceName} ");
        }
    }

    public async Task WebpFileConversion()
    {
        try
        {
            if (!IsBusy)
            {

                IsBusy = true;
                using (var scope = _serviceProvider.CreateScope()) // this will use `IServiceScopeFactory` internally
                {
                    _context = scope.ServiceProvider.GetService<IApplicationDbContext>();
                    var unconvertedImages = await _context.Posts.Where(p => p.ImageUrl == null || string.IsNullOrEmpty(p.ImageUrl)).ToListAsync();
                    var options = new ParallelOptions()
                    {
                        MaxDegreeOfParallelism = 20
                    };
                    if (unconvertedImages.Count > 0)
                    {
                        await Parallel.ForEachAsync(unconvertedImages, options, async (unconvertedImage, ct) =>
                        {

                            var filename = unconvertedImage.TempImageUrl.Replace("https://localhost:7341/files/images/UploadFile/", "");
                            var folder = UploadType.Images.ToString();
                            var folderName = Path.Combine("files", folder);
                            var uploadfile = Path.Combine(folderName, "UploadFile");
                            var filepath = Path.Combine(Directory.GetCurrentDirectory(), uploadfile);
                            var fullPath = Path.Combine(filepath, filename);
                            File.SetAttributes(fullPath, FileAttributes.Normal);
                            var imageBytes = await File.ReadAllBytesAsync(fullPath);
                            var filenamewithoutext = filename.Split(".")[0];
                            using var inStream = new MemoryStream(imageBytes);

                            using var myImage = await Image.LoadAsync(inStream);

                            using var outStream = new MemoryStream();
                            await myImage.SaveAsync(outStream, new WebpEncoder());
                            int fileProvider = _configuration.GetValue<int>("FileProvider");
                            if (fileProvider == 2)
                            {
                                var _azureConnectionString = _configuration.GetConnectionString("AzureConnectionString");
                                var container = new BlobContainerClient(_azureConnectionString, "upload-container");
                                var createResponse = await container.CreateIfNotExistsAsync();
                                if (createResponse != null && createResponse.GetRawResponse().Status == 201)
                                    await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);
                                var blob = container.GetBlobClient(filename);
                                await blob.DeleteIfExistsAsync(DeleteSnapshotsOption.IncludeSnapshots);

                                await blob.UploadAsync(outStream, new BlobHttpHeaders { ContentType = "image/webp" });
                                var uploadService = scope.ServiceProvider.GetService<IUploadService>();
                                uploadService.Remove(Path.Combine(folderName, filename));
                                unconvertedImage.ImageUrl = blob.Uri.ToString();

                                _context.Posts.Update(unconvertedImage);
                                await _context.SaveChangesAsync();
                            }
                            else if (fileProvider == 1)
                            {
                                var features = _server.Features;
                                var addresses = features.Get<IServerAddressesFeature>();
                                var address = addresses.Addresses.FirstOrDefault(); // = http://localhost:5000
                                var uri = new Uri(address);

                                var uploadService = scope.ServiceProvider.GetService<IUploadService>();
                                // Construct the URL to access the file
                                var requestScheme = uri.Scheme; // 'http' or 'https'

                                var requestHost = uri.Host; // 'host:port'

                                outStream.Position = 0;
                                var size = outStream.Length;
                                var uploadRequest = new UploadRequest(
                                    filenamewithoutext,
                                    UploadType.Images,
                                    outStream.ToArray(),
                                   true,
                                    Path.GetExtension(".webp"),
                                    "UploadFile"
                                );
                                var result = await uploadService.UploadAsync(uploadRequest);
                                uploadService.Remove(Path.Combine(folderName, filename));
                                var fileUrl = $"{requestScheme}://{requestHost}/{result.Replace("\\", "/")}";
                                unconvertedImage.ImageUrl = fileUrl;

                                _context.Posts.Update(unconvertedImage);
                                await _context.SaveChangesAsync();
                            }
                        });
                    }
                }
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to run task create batch => {Message}", ex.Message);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
