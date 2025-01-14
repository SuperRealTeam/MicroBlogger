namespace MicroBlogger.ClientApp.Configurations;

public class ClientAppSettings
{
    public const string KEY = nameof(ClientAppSettings);
    public string AppName { get; set; } = "Blazor Aspire";
    public string Version { get; set; } = "1.0.0";
    public string ServiceBaseUrl { get; set; } = "https://localhost:7341";

}

