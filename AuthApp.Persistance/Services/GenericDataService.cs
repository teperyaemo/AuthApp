using AuthApp.Domain.Models;
using AuthApp.Domain.Services;
using AuthApp.Persistance.Services.Common;
using Microsoft.EntityFrameworkCore;

namespace AuthApp.Persistance.Services
{
    public class GenericDataService<T> : IDataService<T> where T : DomainObject
    {
        private readonly AuthAppDbContextFactory _contextFactory;
        private readonly NonQueryDataService<T> _nonQueryDataService;

        public GenericDataService(AuthAppDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
            _nonQueryDataService = new NonQueryDataService<T>(contextFactory);
        }

        public async Task<T> Create(T entity)
        {
            return await _nonQueryDataService.Create(entity);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _nonQueryDataService.Delete(id);
        }

        public async Task<T> Get(Guid id)
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                T entity = await context.Set<T>().FirstOrDefaultAsync((e) => e.Id == id);
                return entity;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            using (AuthAppDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<T> entities = await context.Set<T>().ToListAsync();
                return entities;
            }
        }

        public async Task<T> Update(Guid id, T entity)
        {
            return await _nonQueryDataService.Update(id, entity);
        }
    }
}
