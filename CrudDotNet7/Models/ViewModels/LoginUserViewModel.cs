using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.Models.ViewModels
{
    public class LoginUserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
