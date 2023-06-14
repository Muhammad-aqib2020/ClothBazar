using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ClothBazar.Entities;

namespace ClothBazar.Web.ViewModels
{
    public class NewProductViewModel : BaseEntity
    {
        public string searchterm { get; set; }
        public int PageNo { get; set; }
        //public decimal Price { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }
        public List<Product> Products { get; set; }


        public List<CategoryViewModel> CategoryViewModels { get; set; }

    }

    public class ProductViewModel
    {
        public Product product { get; set; }

    }
}