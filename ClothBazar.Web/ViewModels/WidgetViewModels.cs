using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    public class ProductwidgetViewModel
    {
        public List<Product> products { get; set; }
        public bool IsLatestProduct { get; set; }
    }
}