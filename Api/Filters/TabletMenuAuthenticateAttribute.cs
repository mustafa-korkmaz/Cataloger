using System.Collections.Generic;
using System.Web.Http.Filters;
using System.Linq;
using Api.Common;
using System.Web.Http.Controllers;

namespace Api.Filters
{
    public class TabletMenuAuthenticateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            IEnumerable<string> headerValues;
            actionContext.Request.Headers.TryGetValues(App.IntegrationKeyHeaderName, out headerValues);

            string integrationKeyHash = string.Empty;

            if (headerValues != null)
            {
                integrationKeyHash = headerValues.FirstOrDefault();
            }

            if (!IsRequestAuthenticated(integrationKeyHash))
            {
                // return 403 (forbidden)
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            else
                base.OnActionExecuting(actionContext);
        }

        private bool IsRequestAuthenticated(string integrationKeyHash)
        {
            if (string.IsNullOrEmpty(integrationKeyHash))
            {
                return false;
            }

            if (integrationKeyHash != App.IntegrationKeyHash)
            {
                return false;
            }
            return true;
        }

    }

}