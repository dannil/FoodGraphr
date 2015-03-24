using FoodGraphr.Model;
using FoodGraphr.Model.API;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr.Controller
{
    /// <summary>
    /// Load the index view and show search results
    /// </summary>
    public class IndexController : NancyModule
    {
        private MatAPI api;

        public IndexController()
        {
            api = new MatAPI();

            //load default index
            Get["/"] = _ =>
            {
                return View["index"];
            };

            //load search result based on input in form
            Post["/"] = _ =>
            {
                string name = Request.Form["name"];

                List<Food> foods = api.SearchFood(name);

                List<Food> sortedFoods = new List<Food>();
                if (name != string.Empty)
                {
                    // Sort the list by the input
                    sortedFoods = foods.OrderByDescending(f => f.Name.IndexOf(name.First().ToString().ToUpper() + name.Substring(1)))
                                                  .ThenByDescending(f => f.Name.IndexOf(name.First().ToString().ToUpper() + name.Substring(1) + " "))
                                                  .ThenBy(f => f.Name.Split(' ').Count())
                                                  .ToList();
                }
                else
                {
                    // The user didn't search for anything, order by default (which is Number)
                    sortedFoods = foods;
                }
                return View["searchresult", sortedFoods];
            };
        }
    }
}