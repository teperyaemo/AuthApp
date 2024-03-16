using AuthApp.Domain.Models;
using AuthApp.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;


    namespace AuthApp.Persistance
    {
        public class AuthAppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.ApplyConfiguration(new UserConfigurations());
                base.OnModelCreating(builder);
            }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                    optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False", 
                        b=> b.MigrationsAssembly("AuthApp.Persistance"));

                    base.OnConfiguring(optionsBuilder);
            }
        }
    }
