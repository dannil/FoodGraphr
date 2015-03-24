using Nancy;
using FoodGraphr.Model;
using FoodGraphr.Model.Charts;
using System.Collections.Generic;
using System.Web;
using FoodGraphr.Model.API;

namespace FoodGraphr.Controller
{
    /// <summary>
    /// To load the documentation view
    /// </summary>
    public class DocumentationController: NancyModule
    {
        private MatAPI api;
        public DocumentationController() : base("/documentation")
        {
            api = new MatAPI();

            //load view
            Get["/"] = _ =>
            {
                return View["documentation"];
            }; 
        }
    }
}