using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr.Model.API
{
    /// <summary>
    /// Class which communicates with matapi.se and binds the result to objects.
    /// </summary>
    public class MatAPI
    {
        private string url;
        
        private RestClient client;

        /// <summary>
        /// Constructor
        /// </summary>
        public MatAPI()
        {
            this.url = "http://www.matapi.se";

            // Initialize the REST client which shall make the requests
            this.client = new RestClient(this.url);
        }

        /// <summary>
        /// Get a food with the specified id
        /// </summary>
        /// <param name="id">The id of the food.</param>
        /// <returns>The food which has the specified id.</returns>
        public Food GetFood(int id)
        {
            RestRequest request = new RestRequest("foodstuff/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            RestResponse<Food> response = (RestResponse<Food>)this.client.Execute<Food>(request);
            return response.Data;
        }

        /// <summary>
        /// Get all foods
        /// </summary>
        /// <returns>A list of all available foods</returns>
        public List<Food> GetFoods()
        {
            RestRequest request = new RestRequest("foodstuff", Method.GET);

            RestResponse<List<Food>> response = (RestResponse<List<Food>>)this.client.Execute<List<Food>>(request);
            return response.Data;
        }

        /// <summary>
        /// Search for foods which matches the specified name
        /// </summary>
        /// <param name="name">The name to search for.</param>
        /// <returns>A list of foods which matches the specified name.</returns>
        public List<Food> SearchFood(string name)
        {
            RestRequest request = new RestRequest("foodstuff?query={name}", Method.GET);
            request.AddUrlSegment("name", name.ToString());

            RestResponse<List<Food>> response = (RestResponse<List<Food>>)this.client.Execute<List<Food>>(request);
            return response.Data;
        }

        /// <summary>
        /// Get all nutrients as a dictionary for easier access
        /// </summary>
        /// <returns>A dictionary whhere every entry has the slug as the key and the nutrient object as the value</returns>
        public Dictionary<string, Nutrient> GetNutrients()
        {
            RestRequest request = new RestRequest("nutrient", Method.GET);

            RestResponse<List<Nutrient>> response = (RestResponse<List<Nutrient>>)this.client.Execute<List<Nutrient>>(request);

            // Save the fetched list as a dictionary
            Dictionary<string, Nutrient> dictionary = new Dictionary<string, Nutrient>();
            foreach (Nutrient n in response.Data)
            {
                dictionary.Add(n.Slug, n);
            }
            return dictionary;
        }
    }
}