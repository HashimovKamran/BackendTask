using System.ComponentModel.DataAnnotations;

namespace BackendTask.Domain.DTOs
{
    public class EntityDTO
    {
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
