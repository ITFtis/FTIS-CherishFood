using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace RSLRegisterWeb
{
    public static class RouteConfig
    {
          public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings {AutoRedirectMode = RedirectMode.Off};
            routes.EnableFriendlyUrls(settings, new Microsoft.AspNet.FriendlyUrls.Resolvers.IFriendlyUrlResolver[] { new MyWebFormsFriendlyUrlResolver() });
        }
        private class MyWebFormsFriendlyUrlResolver : Microsoft.AspNet.FriendlyUrls.Resolvers.WebFormsFriendlyUrlResolver
        {
            public override string ConvertToFriendlyUrl(string path)

            {
                if (!string.IsNullOrEmpty(path))
                {
                    if (path.ToLower().Contains("/ckfinder"))
                    {
                        return path;
                    }
                }
                return base.ConvertToFriendlyUrl(path);
            }
        }
    }
}