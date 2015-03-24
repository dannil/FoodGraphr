using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace FoodGraphr.Model.Charts
{
    /// <summary>
    /// All data associated with a chart
    /// </summary>
    public class ChartData
    {
        private string title;

        private string[] data;
        private string[] labels;
        private string[] legends;
        private string[] colors;

        /// <summary>
        /// Generate a formatted string with the values in the array seperated by the seperator
        /// If a value is 0, exclude it
        /// </summary>
        /// <param name="values">values to build string with</param>
        /// <param name="separator">seperator to seperated the values with</param>
        /// <returns></returns>
        public string GenerateParameters(object[] values, char separator)
        {
            StringBuilder builder = new StringBuilder();
            
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != "0")
                {
                    builder.Append(values[i]);
                    if (i < values.Length - 1)
                    {                        
                        builder.Append(separator);
                    }
                }              
            }
            if (builder.ToString()[builder.ToString().Length - 1] == separator)
            {
                builder.Remove(builder.ToString().Length - 1, 1);
            }
            return builder.ToString();
        }

        /// <summary>
        /// Get and set properties for all fields
        /// </summary>

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