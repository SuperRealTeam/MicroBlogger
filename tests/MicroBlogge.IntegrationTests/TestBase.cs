
using NUnit.Framework;

namespace MicroBlogger.IntegrationTests
{

    using static Testing;
    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
