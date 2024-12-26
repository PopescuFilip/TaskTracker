using System.ComponentModel.DataAnnotations;

namespace TaskTrackerWebApp.ViewModels
{
    public class LoginViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password cannot be empty")]
        public string Password { get; set; }
    }
}
