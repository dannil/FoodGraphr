using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyHelloWorld.Model.Charts
{
    public class PieChart : Chart
    {
        private PieChart() : base()
        {
            
        }

        public PieChart(int width, int height) : base(width, height)
        {

        }

        public override string GetUrl()
        {
            return (base.GetUrl() + "&cht=p").Replace(" ", "%20");
        }

    }
}