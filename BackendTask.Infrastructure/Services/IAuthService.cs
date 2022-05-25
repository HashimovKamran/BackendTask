using BackendTask.Domain.DTOs;
using BackendTask.Domain.Entities;
using BackendTask.Domain.Response;
using System.Threading.Tasks;

namespace BackendTask.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<Result> SignIn(SignInDTO signInDTO);
        Task<Result> SignUp(SignUpDTO signUpDTO);
        string CreateAccessToken(User user);
    }
}
