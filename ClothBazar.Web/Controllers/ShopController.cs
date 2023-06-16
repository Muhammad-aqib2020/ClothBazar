using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ShopController : Controller
    {

        //ProductsServices productService = new ProductsServices();

        public ActionResult Checkout()
        {
            CheckoutViewModel model = new CheckoutViewModel();


            var CartProductsCookie = Request.Cookies["CartProducts"];

            if(CartProductsCookie != null)
            {
                //var productsIDs = CartProductsCookie.Value;

                //var Ids = productsIDs.Split('-');
                //List<int> pIds = Ids.Select(x => int.Parse(x)).ToList();

                model.CartProductsIDs = CartProductsCookie.Value.Split('-').Select(x => int.Parse(x)).ToList();

                model.CartProducts = ProductsServices.Instance.GetProducts(model.CartProductsIDs);

            }

            return View(model);
        }

        public ActionResult Index(string searchTerm,int? minimumPrice,int? maximumPrice,int? CategoryID,int? sortBy)
        {
            ShopViewModel model = new ShopViewModel();

            model.FeaturedCategory = CategoriesServices.Instance.GetFeaturedCategories();
            model.MaximumPrice = ProductsServices.Instance.GetMaximumPrice();

            model.Products = ProductsServices.Instance.searchProducts(searchTerm, minimumPrice, maximumPrice, CategoryID, sortBy);
            model.Sortby = sortBy;

            return View(model);
        }
    }
}