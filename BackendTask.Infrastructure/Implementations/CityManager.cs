using BackendTask.DataAccess.Repos;
using BackendTask.Domain.DTOs;
using BackendTask.Domain.Entities;
using BackendTask.Domain.Response;
using BackendTask.Infrastructure.Services;
using BackendTask.Infrastructure.Utilities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.Infrastructure.Implementations
{
    public class CityManager : ICityService
    {
        private readonly IRepository<City> _repository;

        public CityManager(IRepository<City> repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddAsync(CreateCityDTO createCityDTO)
        {
            var city = new City { Name = createCityDTO.CityName, CountryId = createCityDTO.CountryId };
            var result = _repository.AsQueryable().SingleOrDefault(c => c.Id == city.Id);
            if (result != null) return Response.Fail(StandartMessagesUtility.DuplicateDetails);
            await _repository.AddAsync(city);
            return Response.Ok(StandartMessagesUtility.Added);
        }

        public async Task<Result> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
            return Response.Ok(StandartMessagesUtility.Deleted);
        }

        public async Task<Result> GetAllAsync()
        {
            List<CityDTO> list = new List<CityDTO>();
            var cities = await _repository.GetAllAsync();
            if(cities.Count() == 0) return Response.Fail(StandartMessagesUtility.NotFound);
            foreach (var city in cities) list.Add(new CityDTO { Id = city.Id, Name = city.Name, CountryId = city.CountryId });
            return Response.Ok(list);
        }

        public async Task<Result> UpdateAsync(UpdateCityDTO updateCityDTO)
        {
            var city = new City { Id = updateCityDTO.Id, Name = updateCityDTO.CityName, CountryId = updateCityDTO.CountryId };
            await _repository.UpdateAsync(city);
            return Response.Ok(StandartMessagesUtility.Updated);
        }
    }
}
