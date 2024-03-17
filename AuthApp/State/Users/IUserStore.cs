using AuthApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.State.Users
{
    public interface IUserStore
    {
        User CurrentUser { get; set; }
        event Action StateChanged;
    }
}
