using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BackendTask.Domain.Entities
{
    public class Country : Entity
    {
        [Required]
        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
