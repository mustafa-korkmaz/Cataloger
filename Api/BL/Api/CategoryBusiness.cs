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
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            return (from catalog in currentUser.Catalogs
                from category in catalog.Categories
                from property in category.Properties
                select new CategoryPropertiesModel()
                {
                    CategoryId = category.Id, PropertyId = property.Id
                }).ToList();
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