using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace NancyHelloWorld.Model.Charts
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

        public void SetData(float[] datas)
        {
            data.Data = datas;
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
            return URL + "chtt=" + data.Title + 
                         "&chs=" + width + "x" + height + 
                         "&chd=t:" + data.GenerateDataParameters() + 
                         "&chl=" + data.GenerateLabelParameters() + 
                         "&chdl=" + data.GenerateLegendParameters();
        }

    }
}