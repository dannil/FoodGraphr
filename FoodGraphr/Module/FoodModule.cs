using Nancy;
using NancyHelloWorld.Model;
using NancyHelloWorld.Model.Charts;
using NancyHelloWorld.Utility;
using System.Collections.Generic;
using System.Web;

namespace NancyHelloWorld.Module
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

                PieChart chart = new PieChart(540, 280);

                chart.SetTitle(f.Name);
                chart.SetData(new float[] { f.NutrientValues["fat"],
                                            f.NutrientValues["carbohydrates"],
                                            f.NutrientValues["fibres"] });

                chart.SetLabels(new string[] { f.NutrientValues["fat"].ToString() + " g",
                                               f.NutrientValues["carbohydrates"].ToString() + " g",
                                               f.NutrientValues["fibres"].ToString() + " g" });

                chart.SetLegends(new string[] { "Fat", "Carbohydrates", "Fibres" });

                System.Diagnostics.Debug.WriteLine(chart.GetUrl());

                ChartGenerator.GenerateMassChart(f);

                return View["food", f];
            };

            
        }
    }
}