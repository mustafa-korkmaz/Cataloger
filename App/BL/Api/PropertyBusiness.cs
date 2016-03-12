using App.DAL.DTO;
using App.Models;
using App.Models.Api;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace App.BL.Api
{
    /// <summary>
    /// business class for properties controller
    /// </summary>
    public class PropertyBusiness
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<PropertyModel> GetProperties()
        {
            var properties = db.Properties.Select(p => new PropertyModel()
            {
                Id = p.Id,
                Key = p.Key,
                Value = p.Value,
                Status = p.Status,
            });

            return properties;
        }

        internal void Dispose()
        {
            db.Dispose();
        }

        internal bool PropertyExists(int id)
        {
            return db.Properties.Count(i => i.Id == id) > 0;
        }
    }
}