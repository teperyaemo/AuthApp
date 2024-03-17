using AuthApp.Domain.Models;
using AuthApp.Domain.Services;
using AuthApp.Persistance.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Persistance.Services
{
    public class UserDataService : IUserService
    {
        private readonly AuthAppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<User> _nonQueryDataService;

        public UserDataService(AuthAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<User>(contextFactory);
        }
        public async Task<User> Create(User entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<User> Get(Guid id)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                User entity = await context.Users
                    .FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<User>> GetAll()
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<User> entities = await context.Users
                    .ToListAsync();
                return entities;
            }
        }

        public async Task<User> GetByEmail(string email)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                return await context.Users
                    .FirstOrDefaultAsync(a => a.Email == email);
            }
        }

        public async Task<User> Update(Guid id, User entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
