using System;
using System.Collections.Generic;

namespace NancyHelloWorld.Model
{
    public class Food
    {
        private int number;
        private string name;
        private Dictionary<String, float> nutrientValues;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public Dictionary<string, float> NutrientValues
        {
            get { return nutrientValues; }
            set { nutrientValues = value; }
        }

    }
}