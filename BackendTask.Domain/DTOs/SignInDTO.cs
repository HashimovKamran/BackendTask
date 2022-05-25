using System.ComponentModel.DataAnnotations;

namespace BackendTask.Domain.DTOs
{
    public class SignInDTO
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
