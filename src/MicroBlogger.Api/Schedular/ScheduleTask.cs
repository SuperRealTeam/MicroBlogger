using System;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using MicroBlogger.Api.Schedular;

namespace Paychoice.Service.Schedular
{

    public class ScheduleTask : ScheduledProcessor {
    public ScheduleTask(string scheduleExp) : base(scheduleExp) { }

    public override async Task ProcessInScope() {
      await Process();
    }

    protected virtual long GetLastUpdate() {
      //TODO:
      string path = Path.Combine(Directory.GetParent(@"./").FullName, @"last-update\last-updated.txt");
      if (File.Exists(path))
        return new DateTimeOffset(File.GetLastWriteTime(path)).ToUnixTimeMilliseconds();
      return default;
    }

    protected virtual async Task SetLastUpdate() {
      //TODO:
      string path = Path.Combine(Directory.GetParent(@"./").FullName, @"last-update");
      if (!Directory.Exists(path))
        Directory.CreateDirectory(path);
      using (StreamWriter w = File.CreateText(path + @"\last-updated.txt")) {
        await w.WriteLineAsync(DateTime.Now.ToString(CultureInfo.InvariantCulture));
        w.Flush();
        w.Close();
      }
    }
  }
}
