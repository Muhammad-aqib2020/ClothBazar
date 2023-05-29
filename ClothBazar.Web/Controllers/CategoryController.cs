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
    public class CategoryController : Controller
    {
    
        public ActionResult CategoryTable(string search, int? pageNo)
        {
            pageNo = pageNo.HasValue ? pageNo : 1;

            NewCategoryViewModel NMC = new NewCategoryViewModel();
       
            //ProductsServices productservice = new ProductsServices();
        
            var productdata = ProductsServices.Instance.GetProducts(pageNo.Value);
            var categorydata = CategoriesServices.Instance.GetCategories();



            var category = (from c in categorydata
                            join p in productdata
                    on c.ID equals p.CategoryID into ps
                            from data in ps.DefaultIfEmpty()
                            select new CategoryViewModel
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Description = c.Description,
                                Price = data == null ? 0 : data.Price,
                            }).ToList();





            if (!string.IsNullOrEmpty(search))
            {
                categorydata = categorydata.Where(p => p.Name != null && p.Name.Contains(search)).ToList();

                category = (from p in productdata
                            join c in categorydata
                               on p.CategoryID equals c.ID into ps
                            from c in ps.DefaultIfEmpty()
                            select new CategoryViewModel
                            {
                                ID = c.ID,
                                Name = c.Name,
                                Description = c.Description,
                                Price = p.Price,
                            }).ToList();


            }
            NMC.CategoryViewModels = category.ToList();
            return PartialView(NMC.CategoryViewModels);
        }
        [HttpGet]
        public ActionResult Index()
        {
          var categories= CategoriesServices.Instance.GetCategories();

            return View(categories);
        }
       // GET: Category
       [HttpGet]
        public ActionResult Create()
        {
       

            var categories = CategoriesServices.Instance.GetCategories();
            return PartialView(categories);
        }


        [HttpPost]
        public ActionResult Create(Category category)     
        {
            var newCategory = new Category();

            newCategory.Name = category.Name;
            newCategory.Description = category.Description;
            newCategory.ImageURL = category.ImageURL;
            newCategory.IsFeatured = category.IsFeatured;

            CategoriesServices.Instance.SaveCategory(newCategory);

 
            return RedirectToAction("CategoryTable");
        }
        //[HttpPost]
        //public ActionResult Create(NewCategoryViewModel model)
        //{
        //    CategoriesServices categoriesServices = new CategoriesServices();
        //    var newProduct = new Product();

        //    newProduct.Name = model.Name;
        //    newProduct.Description = model.Description;
        //    newProduct.Price = model.Price;
        //    //  newProduct.CategoryID = model.CategoryID;
        //    newProduct.Category = categoriesServices.GetCategory(model.CategoryID);

        //    productservice.SaveProduct(newProduct);

        //    return RedirectToAction("ProductTable");
        //}
        // GET: Category
        [HttpGet]
        public ActionResult Edit(int ID)
        {
            var category = CategoriesServices.Instance.GetCategory(ID);
            return PartialView(category);
        
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            CategoriesServices.Instance.UpdateCategory(category);

            return RedirectToAction("CategoryTable");
        }

        // GET: Category
        [HttpGet]
        public ActionResult Delete(int ID)
        {
            var category = CategoriesServices.Instance.GetCategory(ID);

            //return View(category);
            return RedirectToAction("CategoryTable");
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {


            CategoriesServices.Instance.DeleteCategory(category.ID);

            return RedirectToAction("CategoryTable");
        }

    
    }
}