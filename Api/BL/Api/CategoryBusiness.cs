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
    /// business class for category controller
    /// </summary>
    public class CategoryBusiness
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<CategoryModel> GetCategories(string currentUserId)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var categories =
                     from catalog in currentUser.Catalogs
                     join category in db.Categories on catalog.Id equals category.CatalogId
                     select new CategoryModel()
                     {
                         CatalogId = category.CatalogId,
                         Id = category.Id,
                         Desc = category.Desc,
                         Name = category.Name,
                         Status = category.Status
                     };

            return categories;
        }

        public IEnumerable<CategoryPropertiesModel> GetCategoryProperties(string currentUserId)
        {
            List<CategoryPropertiesModel> categoryProperties = new List<CategoryPropertiesModel>();

            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            foreach (Catalog catalog in currentUser.Catalogs)
            {
                foreach (Category category in catalog.Categories)
                {
                    foreach (Property property in category.Properties)
                    {
                        categoryProperties.Add(new CategoryPropertiesModel()
                        {
                            CategoryId = category.Id,
                            PropertyId = property.Id
                        });
                    }
                }
            }

            return categoryProperties;
        }

        internal void Dispose()
        {
            db.Dispose();
        }

        internal bool CategoryExists(int id)
        {
            return db.Categories.Count(c => c.Id == id) > 0;
        }
    }
}