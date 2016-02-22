using System.Collections.Generic;
using System.Web.Http.Filters;
using System.Linq;
using Api.Common;

namespace Api.Filters
{
    public class TabletMenuAuthenticateAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            IEnumerable<string> headerValues;
            actionExecutedContext.Request.Headers.TryGetValues(App.IntegrationKeyHeaderName, out headerValues);

            string integrationKeyHash = string.Empty;

            if (headerValues != null)
            {
                integrationKeyHash = headerValues.FirstOrDefault();
            }

            if (!RequestIsAuthenticated(integrationKeyHash))
            {
                // return 403 (forbidden)
                actionExecutedContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }
            else
                base.OnActionExecuted(actionExecutedContext);
        }

        private bool RequestIsAuthenticated(string integrationKeyHash)
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