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
                                            f.NutrientValues["protein"],
                                            f.NutrientValues["carbohydrates"],
                                            f.NutrientValues["fibres"],                                             
                                            f.NutrientValues["salt"],
                                            f.NutrientValues["ash"],
                                            f.NutrientValues["water"],
                                            f.NutrientValues["alcohol"]});

                chart.SetLabels(new string[] { f.NutrientValues["fat"].ToString() + " g",
                                               f.NutrientValues["protein"].ToString() + " g",
                                               f.NutrientValues["carbohydrates"].ToString() + " g",
                                               f.NutrientValues["fibres"].ToString() + " g",
                                               f.NutrientValues["salt"].ToString() + " g",
                                               f.NutrientValues["ash"].ToString() + " g",
                                               f.NutrientValues["water"].ToString() + " g",
                                               f.NutrientValues["alcohol"].ToString() + " g"});

                chart.SetLegends(new string[] { "Fat", "Protein", "Carbohydrates", "Fibres", "salt", "ash", "water", "alcohol" });

                chart.SetColors(new string[] { "EBC30C", "D42000", "29E14E", "DDDDDD", "473E3F", "0F1C2E", "4D8DEB", "2D5187" });

                System.Diagnostics.Debug.WriteLine(chart.GetUrl());

                return View["food", f];
            };            
        }
    }
}