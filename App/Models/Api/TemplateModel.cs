using Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Helper;


namespace App.Models.Api
{
    public class TemplateModel
    {
        public int Id { get; set; }

        public TemplateType Type { get; set; }

        public string TypeText
        {
            get
            {
                return Type.ToText();
            }
        }

        public string Desc { get; set; }
    }

}