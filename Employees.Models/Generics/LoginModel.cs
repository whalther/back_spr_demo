using System;

namespace Employees.Models.Generics
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
