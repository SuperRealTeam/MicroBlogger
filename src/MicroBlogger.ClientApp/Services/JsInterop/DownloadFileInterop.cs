using Microsoft.JSInterop;

namespace MicroBlogger.ClientApp.Services.JsInterop;

public sealed class DownloadFileInterop(IJSRuntime jsRuntime)
{
    public async Task DownloadFileFromStream(string fileName, DotNetStreamReference stream)
    {
        await jsRuntime.InvokeVoidAsync("downloadFileFromStream", fileName, stream);
    }
}
