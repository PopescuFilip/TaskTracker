using Microsoft.AspNetCore.Components;
using TaskTrackerWebApp.BusinessLogic;

namespace TaskTrackerWebApp.Components.Pages
{
    public partial class Login
    {
        [Inject]
        public IUserService UserService { get; set; }

        public async Task HandleLogin((string, string) loginInfo)
        {
            var (username, password) = loginInfo;
            var userId = await UserService.Check(username, password);

            if (Guid.TryParse(userId, out _))
            {
                State.UserId = userId;
                Console.WriteLine("succesful login");
            }
        }
    }
}
