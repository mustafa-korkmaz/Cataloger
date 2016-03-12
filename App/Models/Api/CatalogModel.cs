using Common;
using Common.Helper;
using Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.Models.Api
{
    public class CatalogModel
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public CatalogVersion Version { get; set; }

        public string VersionText
        {
            get
            {
                return Version.ToText();
            }
        }

        public Status Status { get; set; }

        public string StatusText
        {
            get
            {
                return Status.ToText();
            }
        }

        public TemplateType TemplateType { get; set; }

        public string TemplateTypeText
        {
            get
            {
                return TemplateType.ToText();
            }
        }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}