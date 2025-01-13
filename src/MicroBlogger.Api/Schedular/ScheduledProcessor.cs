using MicroBlogger.Api.BackgroundService;
using NCrontab;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace MicroBlogger.Api.Schedular;

public abstract class ScheduledProcessor : ScopedProcessor
{
    private readonly CrontabSchedule _schedule;
    private DateTime _nextRun;
    private const string DefaultSchedule = "* * * * *";//"* 12 */1 * *";
    private readonly bool _isDisabled;

    protected ScheduledProcessor(string scheduleExp)
    {
        if (!string.IsNullOrEmpty(scheduleExp) && scheduleExp.Trim() == "-1")
        {
            _isDisabled = true;
            return;
        }

        var scheduleExp1 = string.IsNullOrEmpty(scheduleExp) ? DefaultSchedule : scheduleExp;
        _schedule = CrontabSchedule.Parse(scheduleExp1);
        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        if (_isDisabled) return;
        await Process();
        do
        {
            var now = DateTime.Now;
            //var nextRun = _schedule.GetNextOccurrence(now);
            if (now > _nextRun)
            {
                await Process();
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }
            await Task.Delay(5000, stoppingToken); //5 seconds delay
        }
        while (!stoppingToken.IsCancellationRequested);
    }
}
