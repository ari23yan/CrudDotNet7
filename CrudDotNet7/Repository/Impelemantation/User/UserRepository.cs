using CrudDotNet7.Models.Context;
using CrudDotNet7.Models.Entities;
using CrudDotNet7.Models.ViewModels;
using CrudDotNet7.Repository.Interfacess;
using CrudDotNet7.Utilities.PasswordHelper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CrudDotNet7.Repository.Impelemantation.User
{
    public class UserRepository : IUserRepository
    {
        private readonly CrudDbContext _context;
        private readonly UserManager<Models.Entities.User> _userManager;


        public UserRepository(CrudDbContext crudDbContext, UserManager<Models.Entities.User> userManager)
        {
                _context = crudDbContext;
            _userManager = userManager;
        }
        public async Task<bool> CheckUserIsActive(string userName)
        {
            return await _context.Users.AnyAsync(x => x.UserName == userName && !x.IsDeleted);
        }

        public async Task<List<Models.Entities.User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Models.Entities.User> GetUserById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<bool> DeleteUser(string id)
        {
            var user=  await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if(user != null)
            {
                user.IsDeleted = true;
                _context.Users.Update(user);
                _context.SaveChanges();
            }
            return false;

        }

        public async Task<Models.Entities.User> GetUserByUserName(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName);

        }
            
        public async Task<Models.Entities.User> LoginUser(LoginUserViewModel model)
        {
            if (await CheckUserIsActive(model.UserName))
            {
                var user = await GetUserByUserName(model.UserName);

                var passwordHasher = new PasswordHasher<Models.Entities.User>(); // Replace 'User' with your user model type
                var passwordVerificationResult = passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                if (passwordVerificationResult == PasswordVerificationResult.Success)
                {
                    return user;
                }
                return null;
            }
            return null;
        }
    }
}
