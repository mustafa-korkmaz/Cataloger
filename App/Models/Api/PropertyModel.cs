using Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Helper;


namespace App.Models.Api
{
    public class PropertyModel
    {
        public int Id { get; set; }

        public Key Key { get; set; }

        public string KeyText
        {
            get
            {
                return Key.ToText();
            }
        }

        public string Value { get; set; }

        public Status Status { get; set; }

        public string StatusText
        {
            get
            {
                return Status.ToText();
            }
        }
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