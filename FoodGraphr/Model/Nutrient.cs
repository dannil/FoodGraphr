namespace FoodGraphr.Model
{
    /// <summary>
    /// Class which encapsulates all data belonging to a nutrient
    /// </summary>
    public class Nutrient
    {
        // Instance variables
        private string slug;
        private string name;
        private string unit;

        /// <summary>
        /// Getter/setter for slug
        /// </summary>
        public string Slug
        {
            get { return slug; }
            set { slug = value; }
        }        

        /// <summary>
        /// Getter/setter for name
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }        

        /// <summary>
        /// Getter/setter for unit
        /// </summary>
        public string Unit
        {
            get { return unit; }
            set { unit = value; }
        }        
    }
}