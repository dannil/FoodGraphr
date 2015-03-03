using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NancyHelloWorld.Model
{
    public class API
    {
        private String url;

        private RestClient client;

        public API()
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

        public Nutrient GetNutrient()
        {
            RestRequest request = new RestRequest("nutrient", Method.GET);

            RestResponse<Nutrient> response = (RestResponse<Nutrient>)this.client.Execute<Nutrient>(request);
            return response.Data;
        }

    }
}