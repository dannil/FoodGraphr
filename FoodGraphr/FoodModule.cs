using Nancy;
using NancyHelloWorld.Model;
using RestSharp;
using System.Collections;
using System.Collections.Generic;

namespace NancyHelloWorld
{
    public class FoodModule : NancyModule
    {
        private API api;

        public FoodModule()
        {
            this.api = new API();

            Dictionary<string, Nutrient> test = api.GetNutrients();

            Get["/"] = parameters =>
            {
                Nutrient n = test["fat"];

                return n.Unit;
            };

            Get["/food/{id}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                double total = 0;
                foreach (KeyValuePair<string, double> pair in f.NutrientValues)
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

                return View["food", f];
            };

            
        }
    }
}