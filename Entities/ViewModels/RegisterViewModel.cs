using System.ComponentModel.DataAnnotations;
using Entities.Enums;

namespace Entities.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Name can't be blank")]
        [MinLength(6, ErrorMessage = "UserName should have more than 5 characters")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Email can't be blank")]
        [EmailAddress(ErrorMessage = "Email should be in a proper email address format")]
        public string Email { get; set; }


        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Required(ErrorMessage = "Confirm Password can't be blank")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password and confirm password do not match")]
        public string ConfirmPassword { get; set; }

        public UserType UserType { get; set; } = UserType.User;
    }
}
