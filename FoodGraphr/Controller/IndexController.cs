using FoodGraphr.Model;
using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr.Controller
{
    public class IndexController : NancyModule
    {
        private API api;

        public IndexController()
        {
            api = new API();

            Get["/"] = _ =>
            {
                return View["index"];
            };

            Post["/"] = _ =>
            {
                string name = Request.Form["name"];

                List<Food> foods = api.SearchFood(name);
                List<Food> sortedFoods = foods.OrderByDescending(f => f.Name.IndexOf(name.First().ToString().ToUpper() + name.Substring(1)))
                                              .ThenByDescending(f => f.Name.IndexOf(name.First().ToString().ToUpper() + name.Substring(1) + " "))
                                              .ThenBy(f => f.Name.Split(' ').Count())
                                              .ToList();

                return View["searchresult", sortedFoods];
            };
        }
    }
}