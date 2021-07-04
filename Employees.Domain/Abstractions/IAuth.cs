using Employees.Models.Generics;
using System.Threading.Tasks;

namespace Employees.Domain.Abstractions
{
    public interface IAuth
    {
        Task<string> GenerateJWT(LoginModel userInfo);
        Task<LoginModel> AuthenticateUser(LoginModel login);
    }
}
