using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr.Model.Charts
{
    /// <summary>
    /// Specific pie chart data
    /// </summary>
    public class PieChart : Chart
    {
        private PieChart() : base()
        {            
        }

        public PieChart(int width, int height) : base(width, height)
        {            
        }

        /// <summary>
        /// Adds "&cht=p" to the URL to make it a Pie chart
        /// </summary>
        /// <returns>The genreated URL for the chart</returns>
        public override string GetUrl()
        {
            return (base.GetUrl() + "&cht=p").Replace(" ", "%20");
        }

    }
}