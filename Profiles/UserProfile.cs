using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsersApi.Models;
using UsersAPI.Data.Dto;

namespace UsersApi.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile(){
            CreateMap<CreateUserDto, User>();
            CreateMap<User, IdentityUser<int>>();
        }
    }
}