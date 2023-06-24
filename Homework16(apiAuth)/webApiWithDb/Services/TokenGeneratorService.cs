using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using webApiWithDb.DTOs;
using webApiWithDb.Helpers;

namespace webApiWithDb.Services
{
    public class TokenGeneratorService
    {
        public interface IGenerateToken
        {
            public string GenerateUserToken (CredentialsDto userCredentials);
        }
        public class GenerateTokenService : IGenerateToken
        {
            private readonly AppSettings _appSettings;
            public GenerateTokenService(AppSettings set)
            {
                _appSettings = set;
            }
            public string GenerateUserToken(CredentialsDto userCreds)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                   // new Claim(ClaimTypes.Name, userCreds.Id.ToString()),
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
}
