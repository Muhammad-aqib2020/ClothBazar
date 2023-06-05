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
            CategoryViewModel model = new CategoryViewModel();

            Category category = new Category();
            NewCategoryViewModel NMC = new NewCategoryViewModel();
             pageNo = pageNo.HasValue ? pageNo.Value > 0 ? pageNo.Value : 1 : 1;
            int pageSize = 5;
            NMC.Searchterm = search;
            NMC.products = ProductsServices.Instance.GetProducts(pageNo.Value);
            var totalrecord = CategoriesServices.Instance.GetCategoriesCount(search);
            NMC.categories = CategoriesServices.Instance.GetCategories( search, pageNo.Value);
            
            if (NMC.categories != null)
            {
             
                NMC.Pager = new Pager(totalrecord, pageNo);

                return PartialView(NMC);
            }
            else
            {
                return HttpNotFound();
            }
        }
        [HttpGet]
        public ActionResult Index()
        {
          var categories= CategoriesServices.Instance.GetAllCategories();

            return View(categories);
        }
       // GET: Category
       [HttpGet]
        public ActionResult Create()
        {
       

            var categories = CategoriesServices.Instance.GetAllCategories();
            return PartialView(categories);
        }


        [HttpPost]
        public ActionResult Create(Category category)     
        {
            if (ModelState.IsValid)
            {
                var newCategory = new Category();

                newCategory.Name = category.Name;
                newCategory.Description = category.Description;
                newCategory.ImageURL = category.ImageURL;
                newCategory.IsFeatured = category.IsFeatured;

                CategoriesServices.Instance.SaveCategory(newCategory);


                return RedirectToAction("CategoryTable");
            }
            else
            {
                return new HttpStatusCodeResult(500);
            }
            
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