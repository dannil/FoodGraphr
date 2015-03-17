using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;

namespace FoodGraphr.Model
{
    public class Food
    {
        private int number;
        private string name;
        private string chartUrl;
        private Dictionary<String, float> nutrientValues;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string ChartUrl
        {
            get { return chartUrl; }
            set { chartUrl = value; }
        }

        public Dictionary<string, float> NutrientValues
        {
            get { return nutrientValues; }
            set { nutrientValues = value; }
        }

        public PieChart GeneratePieChart()
        {
            PieChart myChart = new Model.Charts.PieChart(540, 280);

            myChart.SetData(new float[] { nutrientValues["fat"],
                                          nutrientValues["protein"],
                                          nutrientValues["carbohydrates"],
                                          nutrientValues["fibres"],                                             
                                          nutrientValues["salt"],                                          
                                          nutrientValues["water"],
                                          nutrientValues["ash"],
                                          nutrientValues["alcohol"]});

            myChart.SetLabels(new string[] { nutrientValues["fat"].ToString() + " g",
                                             nutrientValues["protein"].ToString() + " g",
                                             nutrientValues["carbohydrates"].ToString() + " g",
                                             nutrientValues["fibres"].ToString() + " g",
                                             nutrientValues["salt"].ToString() + " g",                                             
                                             nutrientValues["water"].ToString() + " g",
                                             nutrientValues["ash"].ToString() + " g",
                                             nutrientValues["alcohol"].ToString() + " g"});

            myChart.SetLegends(new string[] { "Fat (" + nutrientValues["fat"] + " g)",
                                              "Protein (" + nutrientValues["protein"] + " g)",
                                              "Carbohydrates (" + nutrientValues["carbohydrates"] + " g)", 
                                              "Fibres (" + nutrientValues["fibres"] + " g)", 
                                              "Salt (" + nutrientValues["salt"] + " g)", 
                                              "Water (" + nutrientValues["water"] + " g)", 
                                              "Ash (" + nutrientValues["ash"] + " g)", 
                                              "Alcohol (" + nutrientValues["alcohol"] + " g)"});

            myChart.SetColors(new string[] { "EBC30C", "D42000", "29E14E", "DDDDDD", "473E3F", "4D8DEB", "0F1C2E", "2D5187" });

            chartUrl = myChart.GetUrl();

            return myChart;
        }
    }
}