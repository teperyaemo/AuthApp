using AuthApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Domain.Services
{
    public interface IUserService : IDataService<User>
    {
        Task<User> GetByEmail(string email);
    }
}
