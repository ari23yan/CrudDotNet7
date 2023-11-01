namespace CrudDotNet7.Models.ViewModels
{
    public class UserViewModel
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsDeleted { get; set; }
    }
}
