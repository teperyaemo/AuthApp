using AuthApp.Domain.Models;

namespace AuthApp.Domain.Services
{
    public enum RegistrationResult
    {
        Success,
        PasswordsDoNotMatch,
        EmailAlreadyExists
    }
    public interface IAuthenticationService
    {
        Task<RegistrationResult> Register(string firstName, string lastaName,string email, string password, string confirmPassword);
        Task<User> Login(string email, string password);
    }
}
