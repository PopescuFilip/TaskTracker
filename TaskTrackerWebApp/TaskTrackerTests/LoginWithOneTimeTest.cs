using Microsoft.Playwright;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace TaskTrackerTests
{
    [TestClass]
    public class LoginWithOneTimeTest
    {
        public IPlaywright Pw {  get; set; }
        public IBrowser Browser { get; set; }

        [ClassInitialize]
        private async Task InitClass()
        {
            Pw = await Playwright.CreateAsync();
            Browser = await Pw.Chromium.LaunchAsync(new() { Headless = false });
        }
    }
}
