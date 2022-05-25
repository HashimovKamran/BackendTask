using BackendTask.Domain.DTOs;
using BackendTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendTask.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CityController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            var result = await _cityService.GetAllAsync();
            if (!result.Error) return Ok(result.Data);
            return NotFound(result.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddCity(CreateCityDTO createCityDTO)
        {
            var result = await _cityService.AddAsync(createCityDTO);
            if (!result.Error) return Ok(result.Message); 
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> UpdateCity(UpdateCityDTO updateCityDTO)
        {
            var result = await _cityService.UpdateAsync(updateCityDTO);
            if (!result.Error) return Ok(result.Message);
            return BadRequest(result.Message);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> DeleteCity(string id)
        {
            var result = await _cityService.DeleteAsync(id);
            if (!result.Error) return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
