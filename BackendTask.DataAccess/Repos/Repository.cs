using BackendTask.DataAccess.Context;
using BackendTask.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.DataAccess.Repos
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDb _appDb;

        public Repository(AppDb appDb)
        {
            _appDb = appDb;
        }

        public async Task AddAsync(T entity)
        {
            var addedEntity = _appDb.Entry(entity);
            addedEntity.State = EntityState.Added;
            await SaveChangesAsync();
        }

        public IQueryable<T> AsQueryable()
        {
            return _appDb.Set<T>().AsQueryable();
        }

        public async Task DeleteAsync(string id)
        {
            var entity = await _appDb.Set<T>().SingleOrDefaultAsync(x => x.Id == id);
            _appDb.Remove(entity);
            await SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _appDb.Set<T>().ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _appDb.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            var updatedEntity = _appDb.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            await SaveChangesAsync();
        }
    }
}
