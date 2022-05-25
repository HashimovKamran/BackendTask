using BackendTask.Domain.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace BackendTask.Domain.Entities
{
    public abstract class Entity
    {
        public Entity()
        {
            Id = Guid.NewGuid().ToString().KeepAlphanumerics();
        }

        [Key]
        [Required]
        public string Id { get; set; }
    }
}
