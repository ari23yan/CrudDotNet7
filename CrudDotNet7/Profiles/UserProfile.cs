using AutoMapper;
using CrudDotNet7.Models.Entities;
using CrudDotNet7.Models.ViewModels;

namespace CrudDotNet7.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisterUserViewModel>().ReverseMap();
        }
    }
}
