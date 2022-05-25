using BackendTask.Domain.DTOs;
using BackendTask.Domain.Entities;
using BackendTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendTask.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService _countryService;

        public CountryController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _countryService.GetAllAsync();
            if(!result.Error) return Ok(result.Data);
            return NotFound(result.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCountry(CreateCountryDTO createCountryDTO)
        {
            var result = await _countryService.AddAsync(createCountryDTO);
            if (!result.Error) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateCountry(UpdateCountryDTO updateCountryDTO)
        {
            var result = await _countryService.UpdateAsync(updateCountryDTO);
            if (!result.Error) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteCountry(string id)
        {
            var result = await _countryService.DeleteAsync(id);
            if (!result.Error) return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
