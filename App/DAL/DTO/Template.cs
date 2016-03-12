using Common.Enumerations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.DAL.DTO
{
    public class Template
    {
        public Template()
        {
            Type = TemplateType.Default; // default value
        }

        public int Id { get; set; }

        [Required]
        public TemplateType Type { get; set; }

        [MaxLength(250)]
        public string Desc { get; set; }

        public virtual ICollection<Catalog> Catalogs { get; set; } // n=>n relation
    }
}