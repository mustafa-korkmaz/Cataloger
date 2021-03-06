﻿using Common.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO
{
    public class Property
    {
        public Property()
        {
            Status = Status.Active;
        }

        public int Id { get; set; }

        [Required]
        public Key Key { get; set; }

        [Required]
        [MaxLength(250)]
        public string Value { get; set; }

        [Required]
        public Status Status { get; set; }

        public virtual ICollection<Item> Items { get; set; } // n=>n relation

        public virtual ICollection<Category> Categories { get; set; } // n=>n relation

        public virtual ICollection<Catalog> Catalogs { get; set; } // n=>n relation
    }
}