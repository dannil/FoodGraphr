using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace FoodGraphr.Model.Charts
{
    /// <summary>
    /// Definition of a chart
    /// </summary>
    public abstract class Chart
    {
        protected const string URL = "http://chart.apis.google.com/chart?";

        protected ChartData chartData;

        protected int width;
        protected int height;

        protected Chart()
        {
            chartData = new ChartData();
        }

        /// <summary>
        /// Set width and height at initiation
        /// </summary>
        /// <param name="width">width to set</param>
        /// <param name="height">height to set</param>
        protected Chart(int width, int height) : this()
        {
            this.width = width;
            this.height = height;
        }

        /// <summary>
        /// Set the title of the chart
        /// </summary>
        /// <param name="title">title to set</param>
        public void SetTitle(string title)
        {
            chartData.Title = title;
        }

        /// <summary>
        /// Fill the chart with data
        /// </summary>
        /// <param name="data">data to fill chart with</param>
        public void SetData(float[] data)
        {
            string[] dataAsString = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataAsString[i] = data[i].ToString();
                dataAsString[i] = dataAsString[i].Replace(",", ".");
            }
            chartData.Data = dataAsString;
        }

        /// <summary>
        /// Set lable of the chart
        /// </summary>
        /// <param name="labels">lable to set</param>
        public void SetLabels(string[] labels)
        {
            chartData.Labels = labels;
        }

        /// <summary>
        /// Set legend of the chart
        /// </summary>
        /// <param name="legends">legend to set</param>
        public void SetLegends(string[] legends)
        {
            chartData.Legends = legends;
        }

        /// <summary>
        /// set colors of the pieces of the chart
        /// </summary>
        /// <param name="colors">array of colors to set</param>
        public void SetColors(string[] colors)
        {
            chartData.Colors = colors;
        }

        /// <summary>
        /// Generate the url of the chart with all data to be viewed
        /// </summary>
        /// <returns>the URL as a string</returns>
        public virtual string GetUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(URL); //base url
            builder.Append("chs=" + width + "x" + height); //width and height
            if (chartData.Title != null)
            {
                builder.Append("&chtt=" + chartData.Title); //title
            }
            if (chartData.Data != null)
            {
                builder.Append("&chd=t:" + chartData.GenerateParameters(chartData.Data, ',')); //chart data, seperate by ,
            }
            if (chartData.Labels != null)
            {
                builder.Append("&chl=" + chartData.GenerateParameters(chartData.Labels, '|')); //lables, seperate by |
            }
            if (chartData.Legends != null)
            {
                builder.Append("&chdl=" + chartData.GenerateParameters(chartData.Legends, '|')); //legends, seperate by |
            }
            if (chartData.Colors != null)
            {
                builder.Append("&chco=" + chartData.GenerateParameters(chartData.Colors, '|')); //colors, seperate by |
            }
            return builder.ToString();
        }

    }
}