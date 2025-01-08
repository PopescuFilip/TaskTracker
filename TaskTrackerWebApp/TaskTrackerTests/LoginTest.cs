using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TaskTrackerTests;

namespace PlaywrightTests;

[TestClass]
public class LoginTest : PageTest
{
    [TestInitialize]
    public async Task Init()
    {
        await Page.GotoAsync($"{Constants.Root}/{Constants.Login}");
    }


    [TestMethod]
    public async Task LoginWithValidCredentials()
    {
        await Page.FillAsync("input[placeholder='Username']", "eu");
        await Page.FillAsync("input[placeholder='Password']", "pass");

        await Page.ClickAsync("button[type='submit']");

        await Expect(Page).ToHaveURLAsync(new Regex($"{Constants.Root}"));
    }

    [TestMethod]
    public async Task LoginWithInvalidCredentials()
    {
        await Page.FillAsync("input[placeholder='Username']", "invalidUsername");
        await Page.FillAsync("input[placeholder='Password']", "invalidPassword");

        await Page.ClickAsync("button[type='submit']");

        var errorMessage = Page.Locator(".text-danger", new() { HasText = "Invalid username or password" });
        await Expect(errorMessage).ToBeVisibleAsync();
    }
}
