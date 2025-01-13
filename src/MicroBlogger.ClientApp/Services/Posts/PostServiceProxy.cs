// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MicroBlogger.Api.Client;
using MicroBlogger.Api.Client.Models;
using MicroBlogger.ClientApp.Services.JsInterop;
using MicroBlogger.ClientApp.Services.Products;
using MicroBlogger.ClientApp.Services.PushNotifications;
using Microsoft.AspNetCore.Components;
using OneOf;

namespace MicroBlogger.ClientApp.Services.Posts;

public class PostServiceProxy
{
    private readonly NavigationManager _navigationManager;
    private readonly PostCacheService _postCacheService;
    private readonly IWebpushrService _webpushrService;
    private readonly ApiClient _apiClient;

    private readonly OnlineStatusInterop _onlineStatusInterop;
    private readonly OfflineModeState _offlineModeState;
    private readonly OfflineSyncService _offlineSyncService;
    private bool _previousOnlineStatus;
    public PostServiceProxy(NavigationManager navigationManager, PostCacheService postCacheService, IWebpushrService webpushrService, ApiClient apiClient, OnlineStatusInterop onlineStatusInterop, OfflineModeState offlineModeState, OfflineSyncService offlineSyncService)
    {
        _navigationManager = navigationManager;
        _postCacheService = postCacheService;
        _webpushrService = webpushrService;
        _apiClient = apiClient;
        _onlineStatusInterop = onlineStatusInterop;
        _offlineModeState = offlineModeState;
        _offlineSyncService = offlineSyncService;
        Initialize();
    }
    private void Initialize()
    {
        _onlineStatusInterop.OnlineStatusChanged -= OnOnlineStatusChanged;
        _onlineStatusInterop.OnlineStatusChanged += OnOnlineStatusChanged;
    }
    private async void OnOnlineStatusChanged(bool isOnline)
    {
        if (_previousOnlineStatus == isOnline)
            return;
        _previousOnlineStatus = isOnline;
        if (isOnline)
        {
            await SyncOfflineCachedDataAsync();
        }
    }
    public async Task<PaginatedResultOfPostsDto> GetPaginatedProductsAsync(PostsWithPaginationQuery paginationQuery)
    {
        var isOnline = await _onlineStatusInterop.GetOnlineStatusAsync();
        if (!isOnline)
        {
            var cachedResult = await _postCacheService.GetPaginatedProductsAsync(paginationQuery);
            return cachedResult ?? new PaginatedResultOfPostsDto();
        }
        try
        {
            var paginatedProducts = await _apiClient.Posts.Pagination.PostAsync(paginationQuery);
            if (paginatedProducts != null && _offlineModeState.Enabled)
            {
                await _postCacheService.SaveOrUpdatePaginatedProductsAsync(paginationQuery, paginatedProducts);

                foreach (var productDto in paginatedProducts.Items)
                {
                    await _postCacheService.SaveOrUpdatePostAsync(productDto);
                }
            }
            return paginatedProducts ?? new PaginatedResultOfPostsDto();
        }
        catch
        {
            return new PaginatedResultOfPostsDto();
        }
    }

    public async Task<OneOf<PostsDto, ApiClientValidationError, ApiClientError>> CreatePostAsync(CreatePostCommand command)
    {
        var isOnline = await _onlineStatusInterop.GetOnlineStatusAsync();
        if (isOnline)
        {
            try
            {
                var response = await _apiClient.Posts.PostAsync(command);
                var baseUrl = _navigationManager.BaseUri.TrimEnd('/');
                var postUrl = $"{baseUrl}/posts/edit/{response.PostId}";
                await _webpushrService.SendNotificationAsync(
                    "New Post!",
                    $"{response.Message}!",
                    postUrl
                );

                return response;
            }
            catch (HttpValidationProblemDetails ex)
            {
                return new ApiClientValidationError(ex.Detail, ex);
            }
            catch (ProblemDetails ex)
            {
                return new ApiClientError(ex.Detail, ex);
            }
            catch (Exception ex)
            {
                return new ApiClientError(ex.Message, ex);
            }
        }
        else
        {
            if (_offlineModeState.Enabled)
            {
                await _postCacheService.StoreOfflineCreateCommandAsync(command);
                var postId = Guid.NewGuid().ToString();
                var postDto = new PostsDto()
                {
                    PostId = postId,
                    Message = command.Message,
                    TempImageUrl = command.TempImageUrl,
                    ImageUrl = command.ImageUrl,
                    Latitude = command.Latitude,
                    Longtuide  = command.Longtuide                    
                };
                await _postCacheService.SaveOrUpdatePostAsync(postDto);

                var cachedPaginatedPosts = await _postCacheService.GetAllCachedPaginatedResultsAsync();
                if (cachedPaginatedPosts.Any())
                {
                    foreach (var kvp in cachedPaginatedPosts)
                    {
                        var paginatedPosts = kvp.Value;
                        paginatedPosts.Items.Insert(0, postDto);
                        paginatedPosts.TotalItems++;
                        await _postCacheService.SaveOrUpdatePaginatedPostsAsync(kvp.Key, paginatedPosts);
                    }
                }
                return postDto;
            }
            else
            {
                return new ApiClientError("Offline mode is disabled. Please enable offline mode to create products in offline mode.", new Exception("Offline mode is disabled."));
            }
        }
    }

    public async Task SyncOfflineCachedDataAsync()
    {
        var (totalCount, cachedCreatePostCommands) = await _postCacheService.GetAllPendingCommandsAsync();
        if (totalCount > 0)
        {
            var processedCount = 0;
            _offlineSyncService.SetSyncStatus(SyncStatus.Syncing, $"Starting sync: 0/{totalCount} ...", totalCount, processedCount);
            await Task.Delay(500);

            async Task ProcessCommandsAsync<T>(IEnumerable<T> commands, Func<T, Task> action)
            {
                foreach (var command in commands)
                {
                    processedCount++;
                    await action(command);
                    _offlineSyncService.SetSyncStatus(SyncStatus.Syncing, $"Syncing {processedCount}/{totalCount} Success.", totalCount, processedCount);
                    await Task.Delay(500);
                }
            }

            if (cachedCreatePostCommands != null && cachedCreatePostCommands.Any())
            {
                await ProcessCommandsAsync(cachedCreatePostCommands, CreatePostAsync);
            }



            _offlineSyncService.SetSyncStatus(SyncStatus.Completed, $"Sync completed: {processedCount}/{totalCount} processed.", totalCount, processedCount);
            await Task.Delay(1200);
        }
        await _postCacheService.ClearCommands();
        _offlineSyncService.SetSyncStatus(SyncStatus.Idle, "", 0, 0);
    }
}
