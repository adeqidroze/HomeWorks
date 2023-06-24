using Database.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using webApiWithDb.DTOs;
using webApiWithDb.Services;
using static webApiWithDb.Services.TokenGeneratorService;

namespace webApiWithDb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserInterface _userservice;
        private readonly IGenerateToken _UserToken;

        public UserController(IUserInterface userservice, IGenerateToken generateToken )
        {
            _userservice = userservice;
            _UserToken = generateToken;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] CredentialsDto user)
        {
            var userLogin = _userservice.Login(user);
            if (userLogin == null) 
            {
                return BadRequest(new { message = "Access denied. Wrong Username or Password." });
            }

            return Ok(new {});
        }
    }
}
