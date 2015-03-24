using Nancy;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;
using System.Collections.Generic;
using System.Web;
using FoodGraphr.Model.API;

namespace FoodGraphr.Controller
{
    public class DocumentationController: NancyModule
    {
        private MatAPI api;
        public DocumentationController() : base("/documentation")
        {
            api = new MatAPI();

            Get["/"] = _ =>
            {
                return View["documentation"];
            }; 
        }
    }
}