using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr.Model.API
{
    public class MatAPI
    {
        private String url;

        private RestClient client;

        public MatAPI()
        {
            this.url = "http://www.matapi.se";

            this.client = new RestClient(this.url);
        }

        public Food GetFood(int id)
        {
            RestRequest request = new RestRequest("foodstuff/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());

            RestResponse<Food> response = (RestResponse<Food>)this.client.Execute<Food>(request);
            return response.Data;
        }

        public List<Food> GetFoods()
        {
            RestRequest request = new RestRequest("foodstuff", Method.GET);

            RestResponse<List<Food>> response = (RestResponse<List<Food>>)this.client.Execute<List<Food>>(request);
            return response.Data;
        }       

        public Dictionary<string, Nutrient> GetNutrients()
        {
            RestRequest request = new RestRequest("nutrient", Method.GET);

            RestResponse<List<Nutrient>> response = (RestResponse<List<Nutrient>>)this.client.Execute<List<Nutrient>>(request);

            Dictionary<string, Nutrient> dictionary = new Dictionary<string, Nutrient>();
            foreach (Nutrient n in response.Data)
            {
                dictionary.Add(n.Slug, n);
            }
            return dictionary;
        }

        public List<Food> SearchFood(string name)
        {
            RestRequest request = new RestRequest("foodstuff?query={name}", Method.GET);
            request.AddUrlSegment("name", name.ToString());

            RestResponse<List<Food>> response = (RestResponse<List<Food>>)this.client.Execute<List<Food>>(request);
            return response.Data;
        }
    }
}