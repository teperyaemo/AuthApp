using AuthApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly PasswordHasher<User> _passwordHasher;
        public async Task<bool> Login(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Registration(string firstName, string lastaName, DateTime dateBirth, string email, string password, string confirmPassword)
        {
            bool success = false;

            if(password == confirmPassword)
            {
                User user = new User()
                {
                    Id = Guid.NewGuid(),
                    Email = email,
                    FirstName = firstName,
                    LastName = lastaName,
                    DateBirth = dateBirth,
                    Password = ""
                };
                
                string hashPassword = _passwordHasher.HashPassword(user, password);

            }

            return success;

        }
    }
}
