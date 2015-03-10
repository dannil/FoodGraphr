using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace FoodGraphr.Model.Charts
{
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

        protected Chart(int width, int height) : this()
        {
            this.width = width;
            this.height = height;
        }

        public void SetTitle(string title)
        {
            chartData.Title = title;
        }

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

        public void SetLabels(string[] labels)
        {
            chartData.Labels = labels;
        }

        public void SetLegends(string[] legends)
        {
            chartData.Legends = legends;
        }

        public void SetColors(string[] colors)
        {
            chartData.Colors = colors;
        }

        public virtual string GetUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(URL);
            builder.Append("chs=" + width + "x" + height);
            if (chartData.Title != null)
            {
                builder.Append("&chtt=" + chartData.Title);
            }
            if (chartData.Data != null)
            {
                builder.Append("&chd=t:" + chartData.GenerateParameters(chartData.Data, ','));
            }
            if (chartData.Labels != null)
            {
                builder.Append("&chl=" + chartData.GenerateParameters(chartData.Labels, '|'));
            }
            if (chartData.Legends != null)
            {
                builder.Append("&chdl=" + chartData.GenerateParameters(chartData.Legends, '|'));
            }
            if (chartData.Colors != null)
            {
                builder.Append("&chco=" + chartData.GenerateParameters(chartData.Colors, '|'));
            }
            return builder.ToString();
        }

    }
}