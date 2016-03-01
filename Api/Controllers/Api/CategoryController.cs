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
    public class CategoryController : ApiController
    {
        private CategoryBusiness categoryBusiness = new CategoryBusiness();

        // GET: api/Categories
        [Route("Categories")]
        public IEnumerable<CategoryModel> GetCategories()
        {
            string currentUserId = User.Identity.GetUserId();

            return categoryBusiness.GetCategories(currentUserId);
        }

        //GET: api/CategoryPropertiess
        [Route("CategoryProperties")]
        public IEnumerable<CategoryPropertiesModel> GetCategoryProperties()
        {
            string currentUserId = User.Identity.GetUserId();

            return categoryBusiness.GetCategoryProperties(currentUserId);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                categoryBusiness.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CategoryExists(int id)
        {
            return categoryBusiness.CategoryExists(id);
        }
    }
}