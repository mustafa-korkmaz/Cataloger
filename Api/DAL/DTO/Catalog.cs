using Api.Common;
using Api.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DAL.DTO
{
    public class Catalog
    {
        public Catalog()
        {
            ModifiedAt = DateTime.Now; // default value
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public CatalogVersion Version { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime ModifiedAt { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; } // n=>n relation

        public virtual ICollection<Category> Categories { get; set; } // 1=>n relation

        public virtual ICollection<Property> Properties { get; set; } // n=>n relation
    }
}