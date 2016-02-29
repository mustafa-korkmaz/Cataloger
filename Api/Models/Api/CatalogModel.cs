using Api.Common;
using Api.Common.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Api
{
    public class CatalogModel
    {
        public int Id { get; set; }

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

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}