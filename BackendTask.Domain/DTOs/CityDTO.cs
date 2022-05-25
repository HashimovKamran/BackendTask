using System.ComponentModel.DataAnnotations;

namespace BackendTask.Domain.DTOs
{
    public class CityDTO : EntityDTO
    {
        [Required]
        public string CountryId { get; set; }
    }
}
