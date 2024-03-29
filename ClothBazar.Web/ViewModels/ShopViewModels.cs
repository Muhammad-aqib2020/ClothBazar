﻿using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothBazar.Web.ViewModels
{
    public class CheckoutViewModel
    {
        public List<Product> CartProducts  { get; set; }
        public List<int> CartProductsIDs { get; set; }
    }
    public class ShopViewModel
    {
        public int MaximumPrice { get; set; }
        public List<Product> Products { get; set; }
        public int? Sortby { get; set; }
        public List<Category> FeaturedCategory { get; set; }
    }
}