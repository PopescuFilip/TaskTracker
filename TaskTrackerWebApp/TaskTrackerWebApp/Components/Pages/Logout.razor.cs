using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;

namespace TaskTrackerWebApp.Components.Pages
{
    public partial class Logout
    {
        [CascadingParameter]
        HttpContext HttpContext { get; set; }

        [Inject]
        NavigationManager NavigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            if (HttpContext.User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
                NavigationManager.NavigateTo("/logout", true);
            }
        }
    }
}