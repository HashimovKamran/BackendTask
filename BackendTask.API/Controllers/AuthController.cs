using BackendTask.Domain.DTOs;
using BackendTask.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackendTask.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInDTO signInDTO)
        {
            var signIn = await _authService.SignIn(signInDTO);
            if (!signIn.Error) return Ok(signIn.Data);
            return BadRequest(signIn.Message);
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpDTO signUpDTO)
        {
            var signUp = await _authService.SignUp(signUpDTO);
            if (!signUp.Error) return Ok(signUp.Message);
            return BadRequest(signUp.Message);
        }
    }
}
