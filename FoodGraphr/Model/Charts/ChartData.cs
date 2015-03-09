using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace FoodGraphr.Model.Charts
{
    public class ChartData
    {
        private string title;

        private string[] data;
        private string[] labels;
        private string[] legends;

        public string GenerateParameters(object[] data, string separator)
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

        public string[] Data
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