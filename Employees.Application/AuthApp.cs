using Employees.DataAccess.Repositories;
using Employees.Domain.Abstractions;
using Employees.Domain.Services;
using Employees.Models.Generics;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application
{
    public class AuthApp
    {
        private readonly IConfiguration _configuration;
        public AuthApp(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<LoginModel> AuthenticateUser(LoginModel userInfo)
        {
            IAuth authRepo = new AuthRepository(_configuration);
            AuthService authService = new AuthService();

            return await authService.AuthenticateUser(authRepo, userInfo);
        }
        public async Task<string> GenerateJWT(LoginModel userInfo)
        {
            IAuth authRepo = new AuthRepository(_configuration);
            AuthService authService = new AuthService();

            return await authService.GenerateJWT(authRepo, userInfo);
        }
    }
}
