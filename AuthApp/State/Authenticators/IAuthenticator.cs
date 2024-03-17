using AuthApp.Domain.Models;
using AuthApp.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.State.Authenticators
{
    public interface IAuthenticator
    {
        User CurrenUser { get; }
        bool IsLoggedIn { get; }

        event Action StateChanged;

        Task<RegistrationResult> Register(string firstName, string lastaName, string email, string password, string confirmPassword);

        Task Login(string email, string password);

        void Logout();
    }
}
