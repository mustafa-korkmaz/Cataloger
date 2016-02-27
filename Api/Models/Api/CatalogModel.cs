using Api.Common;
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

        public Status Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime ModifiedAt { get; set; }
    }
}