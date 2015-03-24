using Nancy;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;
using System.Collections.Generic;
using System.Web;
using FoodGraphr.Model.API;

namespace FoodGraphr.Controller
{
    /// <summary>
    /// Controller for serving food views
    /// </summary>
    public class FoodController : NancyModule
    {
        private MatAPI api;

        /// <summary>
        /// Constructor which contains all mappings for serving food views.
        /// </summary>
        public FoodController() : base("/food")
        {
            api = new MatAPI();

            // Get a food by it's id
            Get["/{id:int}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    // If a food with this id doesn't exists,
                    // return a 404 error page
                    return View["Error/404"];
                }
                // Generate the chart and return the view
                f.GeneratePieChart();
                return View["food", f];
            };
        }
    }
}