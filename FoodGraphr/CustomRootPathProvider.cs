using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodGraphr
{
    public class CustomRootPathProvider : IRootPathProvider
    {
        public string GetRootPath()
        {
            return Environment.CurrentDirectory;
        }
    }
}