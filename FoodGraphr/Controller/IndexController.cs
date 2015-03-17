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

                return View["searchresult", foods];
            };
        }
    }
}