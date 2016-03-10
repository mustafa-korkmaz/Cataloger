using System.Web.Http.Filters;
using System.Net;
using System.Net.Http;
using Api.Common;

namespace Api.Filters
{
    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            //var ex = context.Exception;
            //todo:
            // log  exception
            context.Response.Content = new StringContent(ErrorMessages.ApplicationExceptionMessage); // default error message for client
        }
    }
}