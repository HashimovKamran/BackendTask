using BackendTask.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.DataAccess.Repos
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(string id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> AsQueryable();
        Task SaveChangesAsync();
    }
}
