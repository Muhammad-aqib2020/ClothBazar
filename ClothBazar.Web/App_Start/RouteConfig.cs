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
             name: "Insert",
             url: "Category/Insert",
             defaults: new { controller = "Category", action = "Create" }
         );
            routes.MapRoute(
         name: "EditCategory",
         url: "Category/update",
         defaults: new { controller = "Category", action = "Edit" }
            );

            routes.MapRoute(
             name: "UploadImageProduct",
             url: "Product/UploadImage",
             defaults: new { controller = "Shared", action = "UploadImage" }
             );

            routes.MapRoute(
            name: "DeleteCategory",
             url: "Category/remove",
             defaults: new { controller = "Category", action = "Delete" }
           );

            routes.MapRoute(
                name:"AllProduct",
                url:"Product/fetch",
                defaults: new {controller="Product",action= "ProductTable" }

                );
            routes.MapRoute(
                name:"InsertProduct",
                url:"Product/Insert",
                defaults: new {controller="Product",action="Create"}
                );
            routes.MapRoute(
                name: "EditProduct",
                url: "Product/update",
                defaults: new { controller = "Product", action = "Edit" }
                );
            routes.MapRoute(
                name: "DeleteProduct",
                url: "Product/remove",
                defaults: new { controller = "Product", action = "Delete" }
                );


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
