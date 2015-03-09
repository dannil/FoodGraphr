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

        protected ChartData data;

        protected int width;
        protected int height;

        protected Chart()
        {
            data = new ChartData();
        }

        protected Chart(int width, int height) : this()
        {
            this.width = width;
            this.height = height;
        }

        public void SetTitle(string title)
        {
            data.Title = title;
        }

        public void SetData(float[] data)
        {
            string[] dataAsString = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataAsString[i] = data[i].ToString();
                dataAsString[i] = dataAsString[i].Replace(",", ".");
            }
            this.data.Data = dataAsString;
        }

        public void SetLabels(string[] labels)
        {
            data.Labels = labels;
        }

        public void SetLegends(string[] legends)
        {
            data.Legends = legends;
        }

        public virtual string GetUrl()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(URL);
            builder.Append("chs=" + width + "x" + height);
            if (data.Title != null)
            {
                builder.Append("&chtt=" + data.Title);
            }
            if (data.Data != null)
            {
                builder.Append("&chd=t:" + data.GenerateParameters(data.Data, ","));
            }
            if (data.Labels != null)
            {
                builder.Append("&chl=" + data.GenerateParameters(data.Labels, "|"));
            }
            if (data.Legends != null)
            {
                builder.Append("&chdl=" + data.GenerateParameters(data.Legends, "|"));
            }
            return builder.ToString();
        }

    }
}