using Api.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DAL.DTO
{
    public class Item
    {
        public Item()
        {
            Status = Status.Active;  // default value
        }

        public int Id { get; set; }

        public int CatalogId { get; set; } // foreign key
        public virtual Catalog Catalog { get; set; } //  // navigation for catalog

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<Category> Categories { get; set; } // n=>n relation

        public virtual ICollection<Property> Properties { get; set; } // n=>n relation
    }
}