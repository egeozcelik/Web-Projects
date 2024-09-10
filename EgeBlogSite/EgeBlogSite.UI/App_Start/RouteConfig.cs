using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EgeBlogSite.UI
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
            name: "YeniKayıt",
            url: "UyeOl",
            defaults: new { controller = "Users", action = "Ekle" }
            );

            routes.MapRoute(
              name: "MEkle",
              url: "MakaleEkle",
              defaults: new { controller = "Articles", action = "Ekle" }
              );

            routes.MapRoute(
              name: "YListele",
              url: "YazarListele",
              defaults: new { controller = "Users", action = "Listele" }
              );
            routes.MapRoute(
                name: "MListele",
                url: "MakaleListele",
                defaults: new { controller = "Articles", action = "Listele" }
                );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Welcome", id = UrlParameter.Optional }
            );
        }
    }
}
