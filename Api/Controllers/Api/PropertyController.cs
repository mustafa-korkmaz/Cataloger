using System.Collections.Generic;
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
    public class PropertyController : ApiController
    {
        private PropertyBusiness propertyBusiness = new PropertyBusiness();

        // GET: api/Properties
        [Route("Properties")]
        public IEnumerable<PropertyModel> GetProperties()
        {
            return propertyBusiness.GetProperties();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                propertyBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PropertyExists(int id)
        {
            return propertyBusiness.PropertyExists(id);
        }
    }
}