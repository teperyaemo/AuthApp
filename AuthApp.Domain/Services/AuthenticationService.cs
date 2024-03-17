using AuthApp.Domain.Exceptions;
using AuthApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Principal;

namespace AuthApp.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserService _userService;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthenticationService(IUserService accountService, IPasswordHasher<User> passwordHasher)
        {
            _userService = accountService;
            _passwordHasher = passwordHasher;
        }

        public async Task<User> Login(string email, string password)
        {
            User storedUser = await _userService.GetByEmail(email);

            if (storedUser == null)
            {
                throw new UserNotFoundException(email);
            }

            PasswordVerificationResult passwordResult = _passwordHasher.VerifyHashedPassword(storedUser, storedUser.Password, password);

            if (passwordResult != PasswordVerificationResult.Success)
            {
                throw new InvalidPasswordException(email, password);
            }

            return storedUser;
        }

        public async Task<RegistrationResult> Register(string firstName, string lastaName, string email, string password, string confirmPassword)
        {
            RegistrationResult result = RegistrationResult.Success;

            if (password != confirmPassword)
            {
                result = RegistrationResult.PasswordsDoNotMatch;
            }

            User existUser = await _userService.GetByEmail(email);
            if (existUser != null)
            {
                result = RegistrationResult.EmailAlreadyExists;
            }

            if (result == RegistrationResult.Success)
            {
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastaName,
                    Password = ""
                };

                string hashedPassword = _passwordHasher.HashPassword(user, password);
                user.Password = hashedPassword;

                await _userService.Create(user);
            }

            return result;
        }
    }
}
