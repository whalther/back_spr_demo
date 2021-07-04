using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Employees.Application;
using Employees.Models.Generics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace EmployeesNetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JwtAuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthApp authApp;
        public JwtAuthController (IConfiguration configuration)
        {
            _configuration = configuration;
            authApp = new AuthApp(_configuration);
        }
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel login)
        {
            LoginModel user = await authApp.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = await authApp.GenerateJWT(user);
                return Ok(new { token = tokenString });
            }

            return Unauthorized();
        }
        /*private string GenerateJWT(LoginModel userInfo)
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
        private LoginModel AuthenticateUser(LoginModel login)
        {
            LoginModel user = null;

            if (login.Username == "freecode")
            {
                user = new LoginModel { Username = "freecode", EmailAddress = "freecode@gmail.com" };
            }
            return user;
        }*/

        [HttpGet]
        [Authorize]
        [Route("GetTest")]
        public ActionResult<IEnumerable<string>> GetTest()
        {

            var currentUser = HttpContext.User;
            DateTime TokenDate = new DateTime();

            if (currentUser.HasClaim(c => c.Type == "Date"))
            {
                TokenDate = DateTime.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "Date").Value);

            }

            return Ok("Custom Claims(date): " + TokenDate);

        }
    }
}
