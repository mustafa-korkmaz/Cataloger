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