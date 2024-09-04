using AutoMapper;
using System.Reflection;

namespace API.RequestHelpers
{
    public class UrlResolver<TSource, TDestination> : IValueResolver<TSource, TDestination, string>
    {
        private readonly IConfiguration _config;

        public UrlResolver(IConfiguration config)
        {
            _config = config;
        }

        public string Resolve(TSource source, TDestination destination, string destMember, ResolutionContext context)
        {
            var pictureURLProperty = typeof(TSource).GetProperty("PictureURL", BindingFlags.Public | BindingFlags.Instance);
            if (pictureURLProperty != null)
            {
                var pictureURl = pictureURLProperty.GetValue(source) as string;
                if (!string.IsNullOrEmpty(pictureURl))
                {
                    return _config["ApiUrl"] + pictureURl;
                }
            }

            return string.Empty;
        }

    }
}
