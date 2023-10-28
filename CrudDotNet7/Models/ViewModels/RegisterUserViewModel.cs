using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.Models.ViewModels
{
    public class RegisterUserViewModel
    {
        [Required]
        public string Name { get; set; }
        [Required]

        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [Required]
        [RegularExpression(@"^09\d{9}$", ErrorMessage = "Invalid mobile number.")]
        public string Mobile { get; set; }
    }
}
