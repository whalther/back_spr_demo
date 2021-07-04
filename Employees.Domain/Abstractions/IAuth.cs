using Employees.Models.Generics;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Domain.Abstractions
{
    public interface IAuth
    {
        Task<string> GenerateJWT(LoginModel userInfo);
        Task<LoginModel> AuthenticateUser(LoginModel login);
    }
}
