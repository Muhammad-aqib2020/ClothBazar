using ClothBazar.Entities;
using ClothBazar.Services;
using ClothBazar.Web.ViewModels;
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
            CategoriesServices categoriesServices = new CategoriesServices();

            var categories = categoriesServices.GetCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
            CategoriesServices categoriesServices = new CategoriesServices();
            var newProduct = new Product();

            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
          //  newProduct.CategoryID = model.CategoryID;
            newProduct.Category = categoriesServices.GetCategory(model.CategoryID);

            productservice.SaveProduct(newProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = productservice.GetProduct(ID);
            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(NewCategoryViewModel model)
        {
            CategoriesServices categoriesServices = new CategoriesServices();
            var upProduct = new Product();

            upProduct.Name = model.Name;
            upProduct.Description = model.Description;
            upProduct.Price = model.Price;
            //  newProduct.CategoryID = model.CategoryID;
            upProduct.Category = categoriesServices.GetCategory(model.CategoryID);

            productservice.UpdateProduct(upProduct);

            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            productservice.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}