using AutoMapper;
using CrudDotNet7.Models.Entities;
using CrudDotNet7.Models.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CrudDotNet7.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, RegisterUserViewModel>().ReverseMap();
            CreateMap<User, UserListViewModel>().ReverseMap();
            CreateMap<User, UserViewModel>().ReverseMap();

        }
    }
}
