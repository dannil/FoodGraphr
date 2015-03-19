using Nancy;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;
using System.Collections.Generic;
using System.Web;

namespace FoodGraphr.Controller
{
    public class FoodController : NancyModule
    {
        private API api;

        public FoodController() : base("/food")
        {
            this.api = new API();

            Dictionary<string, Nutrient> test = api.GetNutrients();

            Get["/{id}"] = parameters =>
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