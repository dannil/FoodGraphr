using Nancy;
using Nancy.Responses;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr.Utility
{
    /// <summary>
    /// Class for JSON functionality on objects
    /// </summary>
    public class JsonUtility
    {
        /// <summary>
        /// Convert an object to JSON
        /// </summary>
        /// <param name="o">The object to be converted.</param>
        /// <returns>The JSON representation of the converted object.</returns>
        public static string ConvertToJson(object o)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                // Convert the JSON to camelCase
                ContractResolver = new CamelCasePropertyNamesContractResolver(),

                // Ignore null values on conversion
                NullValueHandling = NullValueHandling.Ignore
            };

            return JsonConvert.SerializeObject(o, settings);
        }

        /// <summary>
        /// Sends a JsonResponse through the web framework; is utilized
        /// to display error messages in JSON format
        /// </summary>
        /// <param name="path">The path the user was on when the response happened.</param>
        /// <param name="statusCode">The current status code of the request.</param>
        /// <param name="message">The message to be displayed to the user.</param>
        /// <returns>A JsonResponse which is served by the web framework.</returns>
        public static JsonResponse DoResponse(string path, HttpStatusCode statusCode, string message) {
            DefaultJsonSerializer defaultSerializer = new DefaultJsonSerializer(); 
            
            return new JsonResponse(new
                                   {
                                       path = path,
                                       code = (int)statusCode,
                                       message = message
                                   }, defaultSerializer) { StatusCode = statusCode };    
        }
    }
}