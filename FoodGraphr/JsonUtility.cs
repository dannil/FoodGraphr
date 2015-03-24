using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr
{
    public class JsonUtility
    {
        public static string ConvertToJson(object o)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(o, settings);
        }

        public static JsonResponse DoResponse(string path, HttpStatusCode statusCode, string message) {
            Nancy.Responses.DefaultJsonSerializer _defaultSerializer = new Nancy.Responses.DefaultJsonSerializer(); 
            
            return new JsonResponse(new
                                   {
                                       path = path,
                                       code = (int)statusCode,
                                       message = statusCode.ToString()
                                   }, _defaultSerializer) { StatusCode = statusCode };    
        }
    }
}