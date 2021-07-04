using Employees.Domain.Abstractions;
using Employees.Models.Generics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Employees.DataAccess.Repositories
{
    public class AuthRepository: IAuth
    {
        private readonly IConfiguration _configuration;        
        public AuthRepository(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        public async Task<string> GenerateJWT(LoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtAuth:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);


            //claim is used to add identity to JWT token
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Username),
                new Claim(JwtRegisteredClaimNames.Email, userInfo.EmailAddress),
                new Claim("Date", DateTime.Now.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(_configuration["JwtAuth:Issuer"],
              _configuration["JwtAuth:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public async Task<LoginModel> AuthenticateUser(LoginModel login)
        {
            LoginModel user = null;

            if (login.Username == "freecode")
            {
                user = new LoginModel { Username = "freecode", EmailAddress = "freecode@gmail.com" };
            }
            return user;
        }
    }
}
