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
    /// business class for item controller
    /// </summary>
    public class ItemBusiness
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<CatalogModel> GetItems(string currentUserId)
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

        public IEnumerable<CatalogPropertiesModel> GetItemProperties(string currentUserId)
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

        internal bool ItemExists(int id)
        {
            return db.Items.Count(i => i.Id == id) > 0;
        }
    }
}