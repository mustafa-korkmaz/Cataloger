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
                Name = c.Name,
                Desc = c.Desc,
                Status = c.Status,
                Version = c.Version,
                CreatedAt = c.CreatedAt,
                ModifiedAt = c.ModifiedAt
            });

            return catalogs;
        }

        public IEnumerable<CatalogPropertiesModel> GetCatalogProperties(string currentUserId)
        {

            List<CatalogPropertiesModel> catalogProperties = new List<CatalogPropertiesModel>();

            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var catalogs = currentUser.Catalogs;

            foreach (Catalog catalog in catalogs)
            {
                foreach (Property property in catalog.Properties)
                {
                    catalogProperties.Add(new CatalogPropertiesModel()
                    {
                        CatalogId = catalog.Id,
                        PropertyId = property.Id
                    });
                }
            }

            return catalogProperties;
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