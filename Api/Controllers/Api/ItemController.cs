﻿using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using Api.DAL.DTO;
using Api.Models.Api;
using Microsoft.AspNet.Identity;
using Api.BL.Api;
using Api.Filters;

namespace Api.Controllers.Api
{
    [CatalogerAuthenticate]  // needs api key
    [Authorize]
    [RoutePrefix("Api")]
    public class ItemController : ApiController
    {
        private ItemBusiness itemBusiness = new ItemBusiness();

        // GET: api/Items
        [Route("Items")]
        public IEnumerable<ItemModel> GetItems()
        {
            string currentUserId = User.Identity.GetUserId();

            return itemBusiness.GetItems(currentUserId);
        }

        //GET: api/ItemPropertiess
        [Route("ItemProperties")]
        public IEnumerable<ItemPropertiesModel> GetItemProperties()
        {
            string currentUserId = User.Identity.GetUserId();

            return itemBusiness.GetItemProperties(currentUserId);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                itemBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ItemExists(int id)
        {
            return itemBusiness.ItemExists(id);
        }
    }
}