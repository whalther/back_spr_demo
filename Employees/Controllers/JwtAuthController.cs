using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Employees.Application;
using Employees.Models.Generics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

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
