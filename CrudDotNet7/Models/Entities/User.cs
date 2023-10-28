using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CrudDotNet7.Models.Entities
{
    public class User: IdentityUser
    {
        public  Guid Id { get; set; }
        public  string Name { get; set; }
        public  string LastName { get; set; }
        public  string Password { get; set; }
        public  string Mobile { get; set; }
        public  bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
