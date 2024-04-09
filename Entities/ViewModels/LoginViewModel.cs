using System.ComponentModel.DataAnnotations;

namespace Entities.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName can't be blank")]
        [MinLength(6, ErrorMessage = "UserName should have more than 5 characters")]
        public string? UserName { get; set; }


        [Required(ErrorMessage = "Password can't be blank")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }

}
