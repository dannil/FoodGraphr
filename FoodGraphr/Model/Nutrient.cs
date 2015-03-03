using System;
using System.Collections.Generic;
using System.Linq;
namespace NancyHelloWorld.Model
{
    public class Nutrient
    {
        private string slug;
        private string name;
        private string unit;

        public string Slug
        {
            get { return slug; }
            set { slug = value; }
        }        

        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }        
    }
}