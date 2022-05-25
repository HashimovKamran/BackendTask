using BackendTask.Domain.DTOs;
using BackendTask.Domain.Response;
using System.Threading.Tasks;

namespace BackendTask.Infrastructure.Services
{
    public interface ICountryService
    {
        Task<Result> AddAsync(CreateCountryDTO createCountryDTO);
        Task<Result> UpdateAsync(UpdateCountryDTO updateCountryDTO);
        Task<Result> DeleteAsync(string id);
        Task<Result> GetAllAsync();
    }
}
