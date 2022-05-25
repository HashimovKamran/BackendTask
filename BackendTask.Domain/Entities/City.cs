using System.ComponentModel.DataAnnotations;

namespace BackendTask.Domain.Entities
{
    public class City : Entity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string CountryId { get; set; }
        public virtual Country Country { get; set; }
    }
}
