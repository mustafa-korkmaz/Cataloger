﻿using Common.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common.Helper;

namespace App.Models.Api
{
    public class ItemModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public string Desc { get; set; }

        public Status Status { get; set; }

        public string StatusText
        {
            get
            {
                return Status.ToText();
            }
        }
    }

}