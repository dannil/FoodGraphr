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

        public FoodController()
        {
            this.api = new API();

            Dictionary<string, Nutrient> test = api.GetNutrients();

            Get["/food/{id}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    return View["Error/404"];
                }
                return View["food", f];
            };            
        }
    }
}