using Microsoft.Playwright.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
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
        var user = "Filip";
        await Page.FillAsync("input[placeholder='Username']", user);
        await Page.FillAsync("input[placeholder='Password']", "pass");

        await Page.ClickAsync("button[type='submit']");

        await Expect(Page).ToHaveURLAsync($"{Constants.Root}/");
        await Expect(Page.Locator("h1")).ToHaveTextAsync("Hello, world!");
        await Expect(Page.Locator("span:has-text('You are logged in as')")).ToBeVisibleAsync();
        await Expect(Page.Locator("b")).ToHaveTextAsync(user);

        await Page.Context.StorageStateAsync(new() { Path = "./loginAuth.json " });
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
