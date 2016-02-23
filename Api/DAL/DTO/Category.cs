using Api.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Api.DAL.DTO
{
    public class Category
    {
        public Category()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }  // foreign key 

        public virtual Category Parent { get; set; } // navigation property
        public virtual ICollection<Category> Children { get; set; }// 1=>n relation

        public int CatalogId { get; set; } // foreign key
        public virtual Catalog Catalog { get; set; } //  // navigation for catalog

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<Item> Items { get; set; } // n=>n relation
        
        public virtual ICollection<Property> Properties { get; set; } // n=>n relation
    }
}