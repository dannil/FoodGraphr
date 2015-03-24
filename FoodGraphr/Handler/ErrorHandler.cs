using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.ErrorHandling;
using Nancy;
using Nancy.Responses;
using Nancy.ViewEngines;
using FoodGraphr.Utility;

namespace FoodGraphr.Handler
{
    /// <summary>
    /// Class which serves different views on request failures. Is essential
    /// to serve nice-looking 404's and 500's, and to stop the web application
    /// from crashing.
    /// </summary>
    public class ErrorHandler : IStatusCodeHandler
    {
        // Instance cariables
        private readonly IEnumerable<ISerializer> serializers;
        private readonly IViewFactory viewFactory;

        /// <summary>
        /// Constructor which automatically runs on every request. 
        /// </summary>
        /// <param name="serializers">The available serializers</param>
        /// <param name="viewFactory">The default view factory for processing views</param>
        public ErrorHandler(IEnumerable<ISerializer> serializers, IViewFactory viewFactory)
        {
            this.serializers = serializers;
            this.viewFactory = viewFactory;
        }

        /// <summary>
        /// A dictionary for saving the available errors views and their names
        /// </summary>
        private readonly IDictionary<HttpStatusCode, string> errorpages = new Dictionary<HttpStatusCode, string>
        {
            { HttpStatusCode.NotFound, "404.cshtml" },
            { HttpStatusCode.InternalServerError, "500.cshtml" },
        };

        /// <summary>
        /// Checks if the current status code has a defined view.
        /// </summary>
        /// <param name="statusCode">The current status code.</param>
        /// <param name="context">The current context of the web application.</param>
        /// <returns>true if the dictionary contains the specified status code; otherwise false.</returns>
        public bool HandlesStatusCode(HttpStatusCode statusCode, NancyContext context)
        {
            return this.errorpages.Keys.Any(s => s == statusCode);
        }

        /// <summary>
        /// Handles the request by supplying the error code
        /// </summary>
        /// <param name="statusCode">The status code to be handled.</param>
        /// <param name="context">The current context of the web application.</param>
        public void Handle(HttpStatusCode statusCode, NancyContext context)
        {
            // If the response for some reason is null or invalid, return
            // immediately as this is an invalid request
            if (context.Response != null && context.Response.Contents != null && !ReferenceEquals(context.Response.Contents, Response.NoBody))
            {
                return;
            }

            string errorPage;

            // If the dictionary doesn't contain the specified status code, return immediately
            if (!this.errorpages.TryGetValue(statusCode, out errorPage))
            {
                return;
            }

            // If the error page string should be null or empty, this is also
            // considered an invalid request
            if (string.IsNullOrEmpty(errorPage))
            {
                return;
            }

            // If nothing failed, serve the response
            DoResponse(statusCode, context, errorPage);
        }

        /// <summary>
        /// Serves a response based on the status code and the error page. Handles API requests
        /// separately as these should not be served as views
        /// </summary>
        /// <param name="statusCode">The status code of the request.</param>
        /// <param name="context">The current context of the web application.</param>
        /// <param name="errorPage">The error page to be served.</param>
        private void DoResponse(HttpStatusCode statusCode, NancyContext context, string errorPage)
        {
            var request = context.Request;

            // Handle for API pages first
            if (request.Url.Path.StartsWith("/api"))
            {
                // Serve a error JSON response with the path the user was on, the current status code
                // and the error message
                var serializer = serializers.FirstOrDefault(s => s.CanSerialize("application/json"));
                context.Response = JsonUtility.DoResponse(request.Url.Path, statusCode, statusCode.ToString());
            }
            else
            {
                // If the URL doesn't begin with "api", it means that the user was on the ordinary webpage.
                // Load the view based on the status code.
                var response = viewFactory.RenderView("Views/Error/" + errorPage, new { StatusCode = (int)statusCode }, new ViewLocationContext { Context = context });

                response.StatusCode = statusCode;
                context.Response = response;
            }
        } 
    }
}