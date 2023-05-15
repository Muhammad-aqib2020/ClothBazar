using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ClothBazar.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "AllCategories",
               url: "Search/All",
               defaults: new { controller = "Category", action = "CategoryTable" }
           );

            routes.MapRoute(
             name: "CreatePage",
             url: "CreatePage",
             defaults: new { controller = "Category", action = "Create" }
         );
            routes.MapRoute(
         name: "EditCategory",
         url: "Category/update",
         defaults: new { controller = "Category", action = "Edit" }
            );

            routes.MapRoute(
            name: "DeleteCategory",
             url: "Category/remove",
             defaults: new { controller = "Category", action = "Delete" }
                    );
            //   routes.MapRoute(
            //name: "CreateCategory",
            //url: "Create/Category",
            //defaults: new { controller = "Category", action = "Create"}
            //);

            //   routes.MapRoute(
            //      name: "AllCategories",
            //      url: "Category/",
            //      defaults: new { controller = "Category", action = "CategoryTable" }
            //  );

            //routes.MapRoute(
            //    name:"EditCategory",
            //    url:"Update/Category",
            //    defaults: new {controller="Category",action="Edit"}
            //    );
            //routes.MapRoute(
            //    name: "DeleteCategory",
            //    url: "Remove/Category",
            //    defaults: new { controller = "Category",action= "Delete" }
            //    );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
