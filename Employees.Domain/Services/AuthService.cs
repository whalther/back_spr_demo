using Employees.Domain.Abstractions;
using Employees.Models.Generics;
using System.Threading.Tasks;

namespace Employees.Domain.Services
{
    public class AuthService
    {
        public async Task<LoginModel> AuthenticateUser(IAuth authRepo, LoginModel userInfo)
        {
            return await authRepo.AuthenticateUser(userInfo);
        }
        public async Task<string> GenerateJWT(IAuth authRepo, LoginModel userInfo)
        {
            return await authRepo.GenerateJWT(userInfo);
        }
    }
}
