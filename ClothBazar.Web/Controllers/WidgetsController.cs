using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class WidgetsController : Controller
    {
        // GET: Widgets
        public ActionResult Products(bool isLatestProducts,int ? CategoryID = 0)
        {
            ProductwidgetViewModel model = new ProductwidgetViewModel();

            model.IsLatestProduct = isLatestProducts;

            if (isLatestProducts)
            {
                model.products= ProductsServices.Instance.GetLatestProducts(4);
            }
            else if(CategoryID.HasValue && CategoryID.Value>0)
            {
                model.products= ProductsServices.Instance.GetProductsbyCategory(CategoryID.Value,4);
            }
            else
            {
                model.products = ProductsServices.Instance.GetProducts(1, 8);
            }

            return PartialView(model);
        }
    }
}