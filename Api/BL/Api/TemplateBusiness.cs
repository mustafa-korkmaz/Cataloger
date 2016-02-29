using Api.DAL.DTO;
using Api.Models;
using Api.Models.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.BL.Api
{
    /// <summary>
    /// business class for properties controller
    /// </summary>
    public class TemplateBusiness
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<TemplateModel> GetTemplates()
        {
            var properties = db.Templates.Select(t => new TemplateModel()
            {
                Id = t.Id,
                Type = t.Type,
                Desc = t.Desc,
            });

            return properties;
        }

        internal void Dispose()
        {
            db.Dispose();
        }

    }
}