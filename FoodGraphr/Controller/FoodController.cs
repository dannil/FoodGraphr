using Nancy;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;
using System.Collections.Generic;
using System.Web;
using FoodGraphr.Model.API;

namespace FoodGraphr.Controller
{
    public class FoodController : NancyModule
    {
        private MatAPI api;

        public FoodController() : base("/food")
        {
            api = new MatAPI();

            Get["/{id:int}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    return View["Error/404"];
                }
                f.GeneratePieChart();
                return View["food", f];
            };            
        }
    }
}