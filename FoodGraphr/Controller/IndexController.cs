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
            Get["/"] = _ =>
            {
                return View["index"];
            };

            Post["/"] = _ =>
            {
                api = new API();

                int id = Request.Form["id"];

                Food f = api.GetFood(id);
                return View["food", f];
            };
        }
    }
}