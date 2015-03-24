using Nancy;
using System.IO;

namespace FoodGraphr
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        private byte[] favicon;

        protected override byte[] FavIcon
        {
            get { return this.favicon ?? (this.favicon = LoadFavIcon()); }
        }

        private byte[] LoadFavIcon()
        {
            //TODO: remember to replace 'AssemblyName' with the prefix of the resource
            using (var resourceStream = GetType().Assembly.GetManifestResourceStream("FoodGraphr.Content.Images.icon.ico"))
            {
                var tempFavicon = new byte[resourceStream.Length];
                resourceStream.Read(tempFavicon, 0, (int)resourceStream.Length);
                return tempFavicon;
            }
        }
    }
}