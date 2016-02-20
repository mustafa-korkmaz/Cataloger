using Api.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.DAL.DTO
{
    public class Item
    {
        public Item()
        {
            Categories = new List<Category>();
            Properties = new List<Property>();
            Status = Status.Active;
        }

        public int Id { get; set; }

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