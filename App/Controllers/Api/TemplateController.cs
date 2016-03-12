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
    public class TemplateController : ApiController
    {
        private TemplateBusiness templateBusiness = new TemplateBusiness();

        // GET: api/Templates
        [Route("Templates")]
        public IEnumerable<TemplateModel> GetProperties()
        {
            return templateBusiness.GetTemplates();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                templateBusiness.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}