using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;
using TaskTrackerWebApp.BusinessLogic;
using TaskTrackerWebApp.Models;
using TaskTrackerWebApp.ViewModels;

namespace TaskTrackerWebApp.Components.Pages
{
    public partial class Register
    {
        [CascadingParameter]
        public HttpContext HttpContext { get; set; }

        [Inject]
        public IUserService UserService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private bool NotAvailableUsername { get; set; }

        [SupplyParameterFromForm]
        public LoginViewModel Model { get; set; } = new();

        public async Task RegisterAccount()
        {
            var newUser = new User()
            {
                Name = Model.Username,
                Password = Model.Password
            };

            var succesfulRegister = await UserService.Post(newUser);

            if (succesfulRegister)
                NavigationManager.NavigateTo(TaskTrackerPages.Login);
            else
                NotAvailableUsername = true;
        }
    }
}
