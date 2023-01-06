using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Identity;
using UsersApi.Models;
using UsersAPI.Data;
using UsersAPI.Data.Dto;

namespace UserAPI.Services
{
    public class SingUpService
    {
        IMapper _mapper;
        UserDbContext _context;
        UserManager<IdentityUser<int>> _userManager;
        public SingUpService(IMapper mapper, UserDbContext context, UserManager<IdentityUser<int>> userManager)
        {
            _mapper = mapper;
            _context = context;
            _userManager = userManager;
        }

        public Result SingUpUser(CreateUserDto createDto)
        {
            User user = _mapper.Map<User>(createDto);
            IdentityUser<int> userIdentity = _mapper.Map<IdentityUser<int>>(user);
            Task<IdentityResult> identityResult = _userManager.CreateAsync(userIdentity, createDto.Password);
            if(identityResult.Result.Succeeded) return Result.Ok();
            return Result.Fail("SingUp Failed");
        }
    }
}