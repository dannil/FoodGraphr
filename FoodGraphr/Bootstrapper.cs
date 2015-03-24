using Nancy;
using System.IO;

namespace FoodGraphr
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override byte[] FavIcon
        {
            get { return null; }
        }
    }
}