using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using mysocietywebsite.Service.Helper;
using mysocietywebsite.Service.interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace mysocietywebsite.Service.jwtauth
{
    public class Auth : IJwtAuth
    {
        private readonly string key;
        public Auth(IOptions<AppSettings> setting)
        {
            this.key = setting.Value.Secret;
        }
        public string Authentication(string userId)
        {

            // 1. Create Security Token Handler
            var tokenHandler = new JwtSecurityTokenHandler();

            // 2. Create Private Key to Encrypted
            var tokenKey = Encoding.ASCII.GetBytes(key);

            //3. Create JETdescriptor
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("id", userId),
                    }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            //4. Create Token
            var token = tokenHandler.CreateToken(tokenDescriptor);

            // 5. Return Token from method
            return tokenHandler.WriteToken(token);
        }
    }
}
