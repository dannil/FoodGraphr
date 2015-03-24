using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;

namespace FoodGraphr.Model
{
    /// <summary>
    /// Class which encapsulates all data belonging to a food. Also
    /// contains logic for generating a chart based on the nutrient
    /// values
    /// </summary>
    public class Food
    {
        // Instance variables
        private int number;
        private string name;
        private string chartUrl;
        private Dictionary<String, float> nutrientValues;

        /// <summary>
        /// Getter/setter for name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        /// <summary>
        /// Getter/setter for number
        /// </summary>
        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        /// <summary>
        /// Getter/setter for the chart url
        /// </summary>
        public string ChartUrl
        {
            get { return chartUrl; }
            set { chartUrl = value; }
        }

        /// <summary>
        /// Getter/setter for the nutrient values
        /// </summary>
        public Dictionary<string, float> NutrientValues
        {
            get { return nutrientValues; }
            set { nutrientValues = value; }
        }

        /// <summary>
        /// Generate a pie chart based on the specified values
        /// </summary>
        /// <returns>A PieChart which contains the specified values.</returns>
        public PieChart GeneratePieChart()
        {
            PieChart myChart = new Model.Charts.PieChart(540, 280);

            // Set the data which the chart should use to calculate the different slices
            myChart.SetData(new float[] { nutrientValues["fat"],
                                          nutrientValues["protein"],
                                          nutrientValues["carbohydrates"],
                                          nutrientValues["fibres"],                                             
                                          nutrientValues["salt"],                                          
                                          nutrientValues["water"],
                                          nutrientValues["ash"],
                                          nutrientValues["alcohol"]});

            // Set labels for easy overview of the chart
            myChart.SetLabels(new string[] { nutrientValues["fat"].ToString() + " g",
                                             nutrientValues["protein"].ToString() + " g",
                                             nutrientValues["carbohydrates"].ToString() + " g",
                                             nutrientValues["fibres"].ToString() + " g",
                                             nutrientValues["salt"].ToString() + " g",                                             
                                             nutrientValues["water"].ToString() + " g",
                                             nutrientValues["ash"].ToString() + " g",
                                             nutrientValues["alcohol"].ToString() + " g"});

            // Set legends for easy overview of the chart
            myChart.SetLegends(new string[] { "Fett (" + nutrientValues["fat"] + " g)",
                                              "Protein (" + nutrientValues["protein"] + " g)",
                                              "Kolhydrater (" + nutrientValues["carbohydrates"] + " g)", 
                                              "Fibrer (" + nutrientValues["fibres"] + " g)", 
                                              "Salt (" + nutrientValues["salt"] + " g)", 
                                              "Vatten (" + nutrientValues["water"] + " g)", 
                                              "Aska (" + nutrientValues["ash"] + " g)", 
                                              "Alkohol (" + nutrientValues["alcohol"] + " g)"});

            // Set colors for each of the slices
            myChart.SetColors(new string[] { "EBC30C", "D42000", "29E14E", "DDDDDD", "E9AEAA", "4D8DEB", "0F1C2E", "2D5187" });

            // Save the url inside the object
            chartUrl = myChart.GetUrl();

            return myChart;
        }
    }
}