using ClothBazar.Entities;
using ClothBazar.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothBazar.Web.Controllers
{
    public class ProductController : Controller
    {
        ProductsServices productservice = new ProductsServices();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search)
        {
            var products = productservice.GetProducts();
            if(!string.IsNullOrEmpty(search))
            {
                products = products.Where(p => p.Name!=null && p.Name.Contains(search.ToLower())).ToList();
            }
       
            return PartialView(products);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Create(Product product)
        {
            productservice.SaveProduct(product);

            return RedirectToAction("ProductTable");
        }
    }
}