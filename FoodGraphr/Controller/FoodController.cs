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

                double total = 0;
                foreach (KeyValuePair<string, float> pair in f.NutrientValues)
                {
                    System.Diagnostics.Debug.WriteLine(pair.Key + " " + pair.Value + " " + test[pair.Key].Unit);

                    switch (test[pair.Key].Unit)
                    {
                        case "g":
                            total += pair.Value;
                            break;
                        case "mg" :
                            total += pair.Value / 1000;
                            break;
                        case "ug" :
                             total += pair.Value / 1000000;
                             break;                        
                    }                        
                }

                System.Diagnostics.Debug.WriteLine("TOTAL: " + total);

                f.GeneratePieChart();

                System.Diagnostics.Debug.WriteLine(f.ChartUrl);

                return View["food", f];
            };            
        }
    }
}