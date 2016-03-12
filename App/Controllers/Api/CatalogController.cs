using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;
using App.DAL.DTO;
using App.Models.Api;
using Microsoft.AspNet.Identity;
using App.BL.Api;
using App.Filters;

namespace App.Controllers.Api
{
    [CatalogerAuthenticate]  // needs api key
    [Authorize]
    [RoutePrefix("Api")]
    [ExceptionHandler]
    public class CatalogController : ApiController
    {
        private CatalogBusiness catalogBusiness = new CatalogBusiness();

        // GET: api/Catalogs
        [Route("Catalogs")]
        public IEnumerable<CatalogModel> GetCatalogs()
        {
            string currentUserId = User.Identity.GetUserId();

            return catalogBusiness.GetCatalogs(currentUserId);
        }

        // GET: api/Catalogs/5
        //[ResponseType(typeof(Catalog))]
        //public IHttpActionResult Catalog(int id)
        //{
        //Catalog catalog = db.Catalogs.Find(id);
        //if (catalog == null)
        //{
        //    return NotFound();
        //}

        //    return Ok(catalog);
        //    return Ok();
        //}

        //GET: api/CatalogPropertiess
        [Route("CatalogProperties")]
        public IEnumerable<CatalogPropertiesModel> GetCatalogProperties()
        {
            string currentUserId = User.Identity.GetUserId();

            return catalogBusiness.GetCatalogProperties(currentUserId);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                catalogBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CatalogExists(int id)
        {
            return catalogBusiness.CatalogExists(id);
        }
    }
}