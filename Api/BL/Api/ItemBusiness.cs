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

        public IEnumerable<ItemModel> GetItems(string currentUserId)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            var items =
               from catalog in currentUser.Catalogs
               join category in db.Categories on catalog.Id equals category.CatalogId
               join item in db.Items on category.Id equals item.CategoryId
               select new ItemModel()
               {
                   Id = item.Id,
                   CategoryId = item.CategoryId,
                   Name = item.Name,
                   Desc = item.Desc,
                   Status = item.Status
               };

            return items;
        }

        public IEnumerable<ItemPropertiesModel> GetItemProperties(string currentUserId)
        {
            ApplicationUser currentUser = db.Users.FirstOrDefault(x => x.Id == currentUserId);

            return (from catalog in currentUser.Catalogs
                from category in catalog.Categories
                from item in category.Items
                from property in item.Properties
                select new ItemPropertiesModel()
                {
                    ItemId = item.Id, PropertyId = property.Id
                }).ToList();
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