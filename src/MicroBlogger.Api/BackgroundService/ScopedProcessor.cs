
using System.Threading.Tasks;

namespace MicroBlogger.Api.BackgroundService;

public abstract class ScopedProcessor : BackgroundService
{
    protected override async Task Process()
    {
        await ProcessInScope();
    }

    public abstract Task ProcessInScope();
}
