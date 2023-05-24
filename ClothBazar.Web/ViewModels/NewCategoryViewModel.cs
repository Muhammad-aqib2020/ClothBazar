using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    public class NewCategoryViewModel 
    {
     
        public string Name { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }

        public int CategoryID { get; set; }
        public List<Product> products { get; set; }
        public List<Category> categories { get; set; }

        public List<CategoryViewModel> CategoryViewModels { get; set; }
    }
}