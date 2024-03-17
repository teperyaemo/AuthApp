using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthApp.Persistance
{
    public class AuthAppDbContextFactory
    {
        private readonly Action<DbContextOptionsBuilder> _configureDbContext;

        public AuthAppDbContextFactory(Action<DbContextOptionsBuilder> configureDbContext)
        {
            _configureDbContext = configureDbContext;
        }

        public AuthAppDbContext CreateDbContext()
        {
            DbContextOptionsBuilder<AuthAppDbContext> options = new DbContextOptionsBuilder<AuthAppDbContext>();

            _configureDbContext(options);

            return new AuthAppDbContext(options.Options);
        }
    }
}
