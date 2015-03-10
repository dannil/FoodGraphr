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
        private string[] colors;

        public string GenerateParameters(object[] values, string separator)
        {
            StringBuilder builder = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != "0")
                {                
                    builder.Append(values[i]);
                    if(i < values.Length-1 && data[i+1] != "0")
                    {
                        builder.Append(separator);
                    }                        
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

        public string[] Colors
        {
            get { return colors; }
            set { colors = value; }
        }

    }
}