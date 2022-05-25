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
    public class CountryManager : ICountryService
    {
        private readonly IRepository<Country> _repository;

        public CountryManager(IRepository<Country> repository)
        {
            _repository = repository;
        }

        public async Task<Result> AddAsync(CreateCountryDTO createCountryDTO)
        {
            var country = new Country { Name = createCountryDTO.CountryName };
            var result = _repository.AsQueryable().SingleOrDefault(c => c.Id == country.Id);
            if (result != null) return Response.Fail(StandartMessagesUtility.DuplicateDetails);
            await _repository.AddAsync(country);
            return Response.Ok(StandartMessagesUtility.Added);
        }

        public async Task<Result> DeleteAsync(string id)
        {
            await _repository.DeleteAsync(id);
            return Response.Ok(StandartMessagesUtility.Deleted);
        }

        public async Task<Result> GetAllAsync()
        {
            List<CountryDTO> list = new List<CountryDTO>();
            var countries = await _repository.GetAllAsync();
            if (countries.Count() == 0) return Response.Fail(StandartMessagesUtility.NotFound);
            foreach (var country in countries) list.Add(new CountryDTO { Id = country.Id, Name = country.Name });
            return Response.Ok(list);
        }

        public async Task<Result> UpdateAsync(UpdateCountryDTO updateCountryDTO)
        {
            var country = new Country { Id = updateCountryDTO.Id, Name = updateCountryDTO.CountryName };
            await _repository.UpdateAsync(country);
            return Response.Ok(StandartMessagesUtility.Updated);
        }
    }
}
