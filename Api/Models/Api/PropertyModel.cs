using Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models.Api
{
    public class PropertyModel
    {
        public int Id { get; set; }

        public Key Key { get; set; }

        public string Value { get; set; }

        public Status Status { get; set; }

    }

    public class CategoryPropertiesModel
    {
        public int CategoryId { get; set; }
        public int PropertyId { get; set; }
    }

    public class ItemPropertiesModel
    {
        public int ItemId { get; set; }
        public int PropertyId { get; set; }
    }

    public class CatalogPropertiesModel
    {
        public int CatalogId { get; set; }
        public int PropertyId { get; set; }
    }

}