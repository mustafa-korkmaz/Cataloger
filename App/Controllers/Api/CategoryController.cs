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
    [ExceptionHandler]
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