var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.MicroBlogger_Api>("apiservice");

builder.AddProject<Projects.MicroBlogger_WebApp>("blazorweb")
     .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
