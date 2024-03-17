using AuthApp.Domain.Models;
using AuthApp.Domain.Services;
using AuthApp.State.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IUserStore _UserStore;

        public Authenticator(IAuthenticationService authenticationService, IUserStore accountStore)
        {
            _authenticationService = authenticationService;
            _UserStore = accountStore;
        }

        public User CurrentUser
        {
            get
            {
                return _UserStore.CurrentUser;
            }
            private set
            {
                _UserStore.CurrentUser = value;
                StateChanged?.Invoke();
            }
        }

        public bool IsLoggedIn => CurrentUser != null;

        public User CurrenUser => throw new NotImplementedException();

        public event Action StateChanged;

        public async Task Login(string email, string password)
        {
            CurrentUser = await _authenticationService.Login(email, password);
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string firstName, string lastaName, string email, string password, string confirmPassword)
        {
            return await _authenticationService.Register(firstName, lastaName, email, password, confirmPassword);
        }
    }
}
