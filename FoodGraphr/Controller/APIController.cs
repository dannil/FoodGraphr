using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using FoodGraphr.Model;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using FoodGraphr.Model.API;
using FoodGraphr.Utility;

namespace FoodGraphr.Controller
{
    /// <summary>
    /// Controller for creating json response for the request on our API
    /// </summary>
    public class APIController : NancyModule
    {
        private MatAPI api;

        public APIController() : base("/api")
        {
            api = new MatAPI();

            //return all available foodstuff
            Get["/food"] = parameters =>
            {
                List<Food> foods = api.GetFoods();

                var response = (Response)JsonUtility.ConvertToJson(foods);
                response.ContentType = "application/json; charset=utf-8";

                return response;
            };

            //return all info(name, chart-link and nutrients) on requested food id
            Get["/food/{id:int}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    var badResponse = JsonUtility.DoResponse(Request.Path,
                                                             HttpStatusCode.BadRequest,
                                                             HttpStatusCode.BadRequest.ToString() + ", a food with that id doesn't exist");
                    badResponse.ContentType = "application/json; charset=utf-8";
                    return badResponse;
                }

                f.GeneratePieChart();

                var response = (Response)JsonUtility.ConvertToJson(f);
                response.ContentType = "application/json; charset=utf-8";

                return response;
            };

            //return link to chart based on requested food id
            Get["/food/{id:int}/chart"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    var badResponse = JsonUtility.DoResponse(Request.Path,
                                                             HttpStatusCode.BadRequest,
                                                             HttpStatusCode.BadRequest.ToString() + ", a food with that id doesn't exist");
                    badResponse.ContentType = "application/json; charset=utf-8";
                    return badResponse;
                }

                f.GeneratePieChart();

                var response = (Response)JsonUtility.ConvertToJson(f.ChartUrl);
                response.ContentType = "application/json; charset=utf-8";

                return response;
            };

            //return all nutrients of the requested food id
            Get["/food/{id:int}/nutrients"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    var badResponse = JsonUtility.DoResponse(Request.Path,
                                                             HttpStatusCode.BadRequest,
                                                             HttpStatusCode.BadRequest.ToString() + ", a food with that id doesn't exist");
                    badResponse.ContentType = "application/json; charset=utf-8";
                    return badResponse;
                }

                f.GeneratePieChart();

                var response = (Response)JsonUtility.ConvertToJson(f.NutrientValues);
                response.ContentType = "application/json; charset=utf-8";

                return response;
            };

            //return a requested nutrient value from a requested food id
            Get["/food/{id:int}/nutrient/{nutrient}"] = parameters =>
            {
                Food f = api.GetFood(parameters.id);
                if (f.Name == null)
                {
                    var badResponse = JsonUtility.DoResponse(Request.Path,
                                                             HttpStatusCode.BadRequest,
                                                             HttpStatusCode.BadRequest.ToString() + ", a food with that id doesn't exist");
                    badResponse.ContentType = "application/json; charset=utf-8";
                    return badResponse;
                }

                if (!f.NutrientValues.ContainsKey(parameters.nutrient))
                {
                    var badResponse = JsonUtility.DoResponse(Request.Path,
                                                             HttpStatusCode.BadRequest,
                                                             HttpStatusCode.BadRequest.ToString() + ", a nutrient with that name doesn't exist");
                    badResponse.ContentType = "application/json; charset=utf-8";
                    return badResponse;
                }

                float n = f.NutrientValues[parameters.nutrient];

                var response = (Response)JsonUtility.ConvertToJson(n);
                response.ContentType = "application/json; charset=utf-8";

                return response;
            };

            //return name of all avaliavle nutrients and their unit of measurement
            Get["/nutrients"] = parameters =>
            {
                List<Nutrient> nutrients = new List<Nutrient>();
                foreach (KeyValuePair<string, Nutrient> entry in api.GetNutrients())
                {
                    nutrients.Add(entry.Value);
                }

                var response = (Response)JsonUtility.ConvertToJson(nutrients);
                response.ContentType = "application/json; charset=utf-8";

                return response;
            };
        }
    }
}