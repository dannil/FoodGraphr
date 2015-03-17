using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using FoodGraphr.Model;
using System.Web.Script.Serialization;
using Newtonsoft.Json;

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

                var response = (Response)JsonConvert.SerializeObject(f);
                response.ContentType = "application/json";

                return response;
            };
        }
    }
}