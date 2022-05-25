using BackendTask.Domain.DTOs;
using BackendTask.Domain.Response;
using System.Threading.Tasks;

namespace BackendTask.Infrastructure.Services
{
    public interface ICityService
    {
        Task<Result> AddAsync(CreateCityDTO updateCityDTO);
        Task<Result> UpdateAsync(UpdateCityDTO updateCityDTO);
        Task<Result> DeleteAsync(string id);
        Task<Result> GetAllAsync();
    }
}
