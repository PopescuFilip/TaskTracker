using Microsoft.AspNetCore.Components;
using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.Components
{
    public partial class LoginFormComponent
    {
        [Parameter] public EventCallback<(string, string)> OnLogin { get; set; }

        private User User { get; set; } = new User();
        private string Username { get; set; }
        private string Password { get; set; }

        private async Task HandleSubmit()
        {
            await OnLogin.InvokeAsync((Username, Password));
            Username = string.Empty;
            Password = string.Empty;
        }
    }
}