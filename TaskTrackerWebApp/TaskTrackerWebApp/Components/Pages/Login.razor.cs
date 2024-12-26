using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using TaskTrackerWebApp.BusinessLogic;

namespace TaskTrackerWebApp.Components.Pages
{
    public partial class Login
    {
        [CascadingParameter]
        public HttpContext HttpContext { get; set; }

        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        public async Task HandleLogin((string, string) loginInfo)
        {
            var (username, password) = loginInfo;
            var userId = await UserService.Check(username, password);

            if (!Guid.TryParse(userId, out _))
                return;

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, username),
                new(ClaimTypes.Role, "user")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
            NavigationManager.NavigateTo("/");

            Console.WriteLine("succesful login");

        }
    }
}
