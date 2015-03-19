using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ErrorHandling;
using Nancy;
using Nancy.Responses;
using Nancy.ViewEngines;

namespace FoodGraphr.Handler
{
    public class ErrorHandler : IStatusCodeHandler
    {
        private readonly IEnumerable<ISerializer> serializers;
        private IViewFactory viewFactory;

        private readonly IDictionary<HttpStatusCode, string> errorpages = new Dictionary<HttpStatusCode, string>
        {
            { HttpStatusCode.NotFound, "404.cshtml" },
            { HttpStatusCode.InternalServerError, "500.cshtml" },
        }; 

        public ErrorHandler(IEnumerable<ISerializer> serializers, IViewFactory viewFactory)
        {
            this.serializers = serializers;
            this.viewFactory = viewFactory;
        }

        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return this.errorpages.Keys.Any(s => s == statusCode);
        }

        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            if (context.Response != null && context.Response.Contents != null && !ReferenceEquals(context.Response.Contents, Response.NoBody))
            {
                return;
            }

            string errorPage;

            if (!this.errorpages.TryGetValue(statusCode, out errorPage))
            {
                return;
            }

            if (string.IsNullOrEmpty(errorPage))
            {
                return;
            }

            DoResponse(statusCode, context, errorPage);
        }

        private void DoResponse(HttpStatusCode statusCode, NancyContext context, string errorPage)
        {
            var request = context.Request;

            // Handle for API pages first
            if (request.Url.Path.StartsWith("/api"))
            {
                var serializer = serializers.FirstOrDefault(s => s.CanSerialize("application/json"));
                context.Response = new JsonResponse(new
                {
                    path = request.Url.Path,
                    code = HttpStatusCode.NotFound,
                    error = "resource not found"
                }, serializer) { StatusCode = HttpStatusCode.NotFound };
            }
            else
            {
                var response = viewFactory.RenderView("Views/Error/" + errorPage, new { StatusCode = (int)statusCode }, new ViewLocationContext { Context = context });

                response.StatusCode = statusCode;
                context.Response = response;
            }
        } 
    }
}