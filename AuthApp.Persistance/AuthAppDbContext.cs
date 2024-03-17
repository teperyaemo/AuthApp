using AuthApp.Domain.Models;
using AuthApp.Persistance.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;


    namespace AuthApp.Persistance
    {
        public class AuthAppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            public AuthAppDbContext(DbContextOptions options) : base(options) { }
            
            protected override void OnModelCreating(ModelBuilder builder)
            {
                builder.ApplyConfiguration(new UserConfigurations());
                base.OnModelCreating(builder);
            }
        }
    }
