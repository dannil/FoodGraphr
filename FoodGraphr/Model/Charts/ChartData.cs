using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace NancyHelloWorld.Model.Charts
{
    public class ChartData
    {
        private string title;

        private float[] data;
        private string[] labels;
        private string[] legends;

        public string GenerateDataParameters()
        {
            string[] dataAsString = new string[data.Length];
            for (int i = 0; i < data.Length; i++)
            {
                dataAsString[i] = data[i].ToString();
                dataAsString[i] = dataAsString[i].Replace(",", ".");
            }
            return GenerateParameters(dataAsString, ",");
        }

        public string GenerateLabelParameters()
        {
            string[] dataAsString = new string[labels.Length];
            for (int i = 0; i < labels.Length; i++)
            {
                dataAsString[i] = labels[i].ToString();
            }
            return GenerateParameters(dataAsString, "|");
        }

        public string GenerateLegendParameters()
        {
            string[] dataAsString = new string[labels.Length];
            for (int i = 0; i < legends.Length; i++)
            {
                dataAsString[i] = legends[i].ToString();
            }
            return GenerateParameters(dataAsString, "|");
        }

        private string GenerateParameters(string[] data, string separator)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i]);
                if (i != data.Length - 1)
                {
                    builder.Append(separator);
                }
            }
            return builder.ToString();
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public float[] Data
        {
            get { return data; }
            set { data = value; }
        }

        public string[] Labels
        {
            get { return labels; }
            set { labels = value; }
        }

        public string[] Legends
        {
            get { return legends; }
            set { legends = value; }
        }

    }
}