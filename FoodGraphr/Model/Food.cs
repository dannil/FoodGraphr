using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyHelloWorld.Model
{
    public class Food
    {
        private int number;
        private String name;

        private Dictionary<String, double> nutrientValues;

        public Dictionary<String, double> NutrientValues
        {
            get { return nutrientValues; }
            set { nutrientValues = value; }
        }

        public String Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

    }
}