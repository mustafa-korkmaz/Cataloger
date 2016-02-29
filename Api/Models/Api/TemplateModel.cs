using Api.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Api.Common.Helper;


namespace Api.Models.Api
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