using CrudDotNet7.Models.Entities;
using CrudDotNet7.Models.ViewModels;

namespace CrudDotNet7.Repository.Interfacess
{
    public interface IUserRepository
    {
        Task<User>GetUserByUserName(string userName);
        Task<User> GetUserById(string id);
        Task<User> LoginUser(LoginUserViewModel model);
        Task<bool> CheckUserIsActive(string userName);
        Task<List<User>> GetAll();

    }
}
