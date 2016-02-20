using Api.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Api.DAL.DTO
{
    public class Category
    {
        public Category()
        {
            Children = new List<Category>();
            Items = new List<Item>();
            Status = Status.Active;
        }

        public int Id { get; set; }

        public int? ParentId { get; set; }  // foreign key 

        public virtual Category Parent { get; set; } // navigation property
        public virtual ICollection<Category> Children { get; set; }// 1=>n relation

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<Item> Items { get; set; } // n=>n relation
    }
}