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
    /// business class for catalog controller
    /// </summary>
    public class CatalogBusiness
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<CatalogModel> GetCatalogs(string currentUserId)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var catalogs = currentUser.Catalogs.Select(c => new CatalogModel()
            {
                Id = c.Id,
                TemplateId=c.TemplateId,
                Name = c.Name,
                Desc = c.Desc,
                Status = c.Status,
                TemplateType=c.Template.Type,
                Version = c.Version,
                CreatedAt = c.CreatedAt,
                ModifiedAt = c.ModifiedAt
            });

            return catalogs;
        }

        public IEnumerable<CatalogPropertiesModel> GetCatalogProperties(string currentUserId)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var catalogs = currentUser.Catalogs;

            return (from catalog in catalogs
                from property in catalog.Properties
                select new CatalogPropertiesModel()
                {
                    CatalogId = catalog.Id, PropertyId = property.Id
                }).ToList();
        }

        internal void Dispose()
        {
            db.Dispose();
        }

        internal bool CatalogExists(int id)
        {
            return db.Catalogs.Count(e => e.Id == id) > 0;
        }
    }
}