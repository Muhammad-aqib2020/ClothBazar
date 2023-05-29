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
        //ProductsServices productservice = new ProductsServices();
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ProductTable(string search,int ? pageNo)
        {
            NewProductViewModel model = new NewProductViewModel();
          

            model.PageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value :1 : 1;

            model.Products =  ProductsServices.Instance.GetProducts(model.PageNo);
            if(!string.IsNullOrEmpty(search))
            {
                model.searchterm = search;
                model.Products = model.Products.Where(p => p.Name!=null && p.Name.Contains(search.ToLower())).ToList();
            }
       
            return PartialView(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
          

            var categories = CategoriesServices.Instance.GetCategories();
            return PartialView(categories);
        }
        [HttpPost]
        public ActionResult Create(NewCategoryViewModel model)
        {
        
            var newProduct = new Product();

            newProduct.Name = model.Name;
            newProduct.Description = model.Description;
            newProduct.Price = model.Price;
          //  newProduct.CategoryID = model.CategoryID;
            newProduct.Category = CategoriesServices.Instance.GetCategory(model.CategoryID);

            ProductsServices.Instance.SaveProduct(newProduct);

            return RedirectToAction("ProductTable");
        }

        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var product = ProductsServices.Instance.GetProduct(ID);
            return PartialView(product);
        }
        [HttpPost]
        public ActionResult Edit(NewCategoryViewModel model)
        {

            var upProduct = new Product();
            upProduct.ID = model.ID;
            upProduct.Name = model.Name;

            upProduct.Description = model.Description;
            upProduct.Price = model.Price;
            upProduct.CategoryID = model.CategoryID;
            upProduct.Category = CategoriesServices.Instance.GetCategory(model.CategoryID);
            upProduct.ImageURL = model.ImageURL;
            ProductsServices.Instance.UpdateProduct(upProduct);

            return RedirectToAction("ProductTable");
        }
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            ProductsServices.Instance.DeleteProduct(ID);

            return RedirectToAction("ProductTable");
        }
    }
}