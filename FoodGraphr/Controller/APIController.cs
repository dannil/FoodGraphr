using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using FoodGraphr.Model;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace FoodGraphr.Controller
{
    public class APIController : NancyModule
    {
        private API api;

        public APIController()
        {
            api = new API();

            Get["/api/food/{id}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                f.GeneratePieChart();

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };

                var response = (Response)JsonConvert.SerializeObject(f, settings);
                response.ContentType = "application/json";

                return response;
            };
        }
    }
}