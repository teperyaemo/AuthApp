using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Services
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists,
        UsernameAlreadyExists
    }
    public interface IAuthenticationService
    {
        Task<bool> Registration(string FirstName, string LastaName, DateTime dateBirth,string email, string password, string confirmPassword);
        Task<bool> Login(string email, string password);
    }
}
