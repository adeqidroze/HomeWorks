using Database.Data;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using webApiWithDb.DTOs;
using webApiWithDb.Helpers;

namespace webApiWithDb.Services
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(CredentialsDto user);
    }
 
      
    public class TokenGenerateService : ITokenGeneratorService
    {
        private readonly AppSettings _appSettings;
        //private readonly ITokenGeneratorService _tokenGeneratorService;
        private readonly PersonContext _context;
        public TokenGenerateService(IOptions<AppSettings> set, PersonContext personContext ) 
        {        
            _appSettings = set.Value;
            //_tokenGeneratorService = tokenGeneratorService;
            _context = personContext;
        }

        public string GenerateToken(CredentialsDto userCreds)
        {
            var userForRole = _context.Credentials.Where(x => x.Username == userCreds.Username).SingleOrDefault();
            var foundRole = _context.Roles.Where(x => x.Id == userForRole.Id).SingleOrDefault();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                new Claim(ClaimTypes.Name, userForRole.Id.ToString()),
                new Claim(ClaimTypes.Name, foundRole.RoleName.ToString()),
                new Claim(ClaimTypes.Name, userCreds.Username.ToString())

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }


    }

    
}
