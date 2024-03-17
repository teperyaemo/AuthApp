using AuthApp.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AuthApp.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder host)
        {
            host.ConfigureServices((context, services) =>
            {
                string connectionString = context.Configuration.GetConnectionString("sql");
                Action<DbContextOptionsBuilder> configureDbContext = o => o.UseSqlServer(connectionString);

               services.AddDbContext<AuthAppDbContext>(configureDbContext);
                services.AddSingleton<AuthAppDbContextFactory>(new AuthAppDbContextFactory(configureDbContext));
            });

            return host;
        }
    }
}
