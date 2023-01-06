using AutoMapper;
using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAPI.Services;
using UsersAPI.Data.Dto;

namespace UsersAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SingUpController : Controller
    {
        SingUpService _singUpService;
        public SingUpController(SingUpService singUpService)
        {
            _singUpService = singUpService;
        }

        [HttpPost]
        public IActionResult SingUpUser(CreateUserDto createDto){
            Result result = _singUpService.SingUpUser(createDto);
            if(result.IsFailed) return StatusCode(500);
            return Ok();
        }
    }
}
