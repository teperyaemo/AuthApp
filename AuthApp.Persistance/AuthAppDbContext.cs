using AuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;


    namespace AuthApp.Persistance
    {
        public class AuthAppDbContext : DbContext
        {
            public DbSet<User> Users { get; set; }

            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AuthAppDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

                base.OnConfiguring(optionsBuilder);
            }
        }
    }
