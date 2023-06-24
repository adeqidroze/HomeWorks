using Database.Data;
using Database.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Linq;
using webApiWithDb.DTOs;
using webApiWithDb.Helpers;
using webApiWithDb.Services;

namespace webApiWithDb.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserInterface _userservice;
        private readonly ITokenGeneratorService _tokenGeneratorService;
        private readonly AppSettings _appsettings;
        private readonly PersonContext _context;

        public UserController(IUserInterface userservice, IOptions<AppSettings> appSettings, ITokenGeneratorService tokenGeneratorService, PersonContext personContext)

        {
            _userservice = userservice;
            _appsettings = appSettings.Value;
            _tokenGeneratorService = tokenGeneratorService;
            _context = personContext;

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
            var tokenString = _tokenGeneratorService.GenerateToken(userLogin);
            var temp = _context.Credentials.Where(x => x.Username == user.Username).FirstOrDefault();
            var myPerson = _context.Persons.Where(x=> x.Id == temp.Id).FirstOrDefault();
            return Ok(new { 
                USERNAME = user.Username,
                FirstName = myPerson.Firstname,
                LastName = myPerson.Lastname,
                Tocken = tokenString
            });
        }
    }
}
