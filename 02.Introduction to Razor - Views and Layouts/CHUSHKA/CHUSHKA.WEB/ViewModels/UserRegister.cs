using System.ComponentModel.DataAnnotations;

namespace CHUSHKA.WEB.ViewModels
{
    public class UserRegister
    {
        public string Username { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Password must be at least 3 symbols")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match!")]
        public string ConfirmPassword { get; set; }

        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}