using BackendTask.DataAccess.Repos;
using BackendTask.Domain.DTOs;
using BackendTask.Domain.Entities;
using BackendTask.Domain.Response;
using BackendTask.Infrastructure.Services;
using BackendTask.Infrastructure.Utilities;
using System.Linq;
using System.Threading.Tasks;

namespace BackendTask.Infrastructure.Implementations
{
    public class AuthManager : IAuthService
    {
        private readonly IRepository<User> _repository;
        private GenerateJWT _generateJWT;

        public AuthManager(IRepository<User> repository)
        {
            _repository = repository;
            _generateJWT = new GenerateJWT();
        }

        public string CreateAccessToken(User user)
        {
            return _generateJWT.CreateAccessToken(user);
        }

        public async Task<Result> SignIn(SignInDTO signInDTO)
        {
            var user = EmailExists(signInDTO.Email);
            if (user == null) return Response.Fail(StandartMessagesUtility.InvalidCredentials);
            var passwordHash = PasswordHashUtility.ValidatePassword(signInDTO.Password, user.PasswordHash);
            if (!passwordHash) return Response.Fail(StandartMessagesUtility.InvalidCredentials);
            return Response.Ok(CreateAccessToken(user), StandartMessagesUtility.SignIn);
        }

        public async Task<Result> SignUp(SignUpDTO signUpDTO)
        {
            if (EmailExists(signUpDTO.Email) != null) return Response.Fail(StandartMessagesUtility.DuplicateSignUpDetails);
            var passwordHash = PasswordHashUtility.CreateHash(signUpDTO.Password);
            User user = new User { FirstName = signUpDTO.FirstName, LastName = signUpDTO.LastName, Email = signUpDTO.Email, PasswordHash = passwordHash };
            await _repository.AddAsync(user);
            return Response.Ok(string.Empty, StandartMessagesUtility.SignUp);
        }

        private User EmailExists(string email)
        {
            var result = _repository.AsQueryable().SingleOrDefault(e => e.Email == email);
            return result;
        }
    }
}
