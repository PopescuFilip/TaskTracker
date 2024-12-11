using TaskTrackerWebApp.Models;

namespace TaskTrackerWebApp.Components.Layout
{
    public partial class MainLayout
    {
        private bool isLoggedIn = false;

        private async Task HandleLogin(User loginModel)
        {
            isLoggedIn = true;
            return;
            if (loginModel.Name == "admin" && loginModel.Password == "password")
            {
                isLoggedIn = true;
                StateHasChanged();
            }
            else
            {
                Console.WriteLine("Invalid login attempt");
            }
        }
    }
}