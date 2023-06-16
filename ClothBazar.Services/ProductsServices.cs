using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothBazar.Services
{
   public class ProductsServices
    {
        #region Singleton
        public static ProductsServices Instance
        {
            get
            {
                if (instance == null) instance = new ProductsServices();

                return instance;
            }
        }
        private static ProductsServices instance { get; set; }
        private ProductsServices()
        {

        }
        #endregion
        public Product GetProduct(int ID)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(x => x.ID == ID).Include(x => x.Category).FirstOrDefault();
            }
        }
        public List<Product> GetProducts(List<int> IDs)
        {
            using (var context = new CBContext())
            {
                return context.Products.Where(product => IDs.Contains(product.ID)).ToList();
            }
        }
        public List<Product> GetProducts(int pageNo)
        {
            int pageSize = 5;// int.Parse(ConfigurationsServices.Instance.GetConfig("ListingPageSize").Value);

            //  var context = new CBContext();


            using (var context = new CBContext())
            {
                return context.Products.OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Category).ToList();
               //return context.Products.Include(x => x.Category).ToList();
            }
        }

        public List<Product> searchProducts(string searchTerm, int? minimumPrice, int? maximumPrice, int? categoryID,int? sortBy)
        {
         using(var context = new CBContext())
            {
                var products = context.Products.ToList();

                if (categoryID.HasValue)
                {
                    products = products.Where(x => x.Category.ID == categoryID.Value).ToList();
                }

                if(!string.IsNullOrEmpty(searchTerm))
                {
                    products = products.Where(x => x.Name.ToLower().Contains(searchTerm.ToLower())).ToList();
                }
                if (minimumPrice.HasValue)
                {
                    products = products.Where(x => x.Price>= minimumPrice.Value).ToList();
                }
                if (maximumPrice.HasValue)
                {
                    products = products.Where(x => x.Price <= maximumPrice.Value).ToList();
                }
                if(sortBy.HasValue)
                {
                    switch(sortBy.Value)
                    { 
                            
               
                         
                        case 2:
                            products = products.OrderByDescending(x => x.ID).ToList();
                            break;
                        case 3:
                            products = products.OrderBy(x => x.Price).ToList();
                            break;
                        default:
                            products = products.OrderByDescending(x => x.Price).ToList();
                            break;
                    }
                }

                return products;
            }

        }

        public int GetMaximumPrice()
        {
           using(var context = new CBContext())
            {
                var allProducts = context.Products.ToList();
                return (int)(context.Products.Max(x => x.Price));

                  
           
            }
        }

        public List<Product> GetProducts(int pageNo,int pagesize)
        {
          //  int pageSize = 5; int.Parse(ConfigurationsServices.Instance.GetConfig("ListingPageSize").Value);

            //  var context = new CBContext();


            using (var context = new CBContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Skip((pageNo - 1) * pagesize).Take(pagesize).Include(x => x.Category).ToList();
                //return context.Products.Include(x => x.Category).ToList();
            }
        }
        public List<Product> GetProductsbyCategory(int categoryId,int pagesize)
        {
            //  int pageSize = 5; int.Parse(ConfigurationsServices.Instance.GetConfig("ListingPageSize").Value);

            //  var context = new CBContext();


            using (var context = new CBContext())
            {
                return context.Products.Where(x=>x.Category.ID== categoryId).OrderByDescending(x => x.ID).Take(pagesize).Include(x => x.Category).ToList();
                //return context.Products.Include(x => x.Category).ToList();
            }
        }
        public List<Product> GetLatestProducts(int numberofproducta)
        {
           

            using (var context = new CBContext())
            {
                return context.Products.OrderByDescending(x => x.ID).Take(numberofproducta).Include(x => x.Category).ToList();
                //return context.Products.Include(x => x.Category).ToList();
            }
        }
        public void SaveProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product.Category).State = System.Data.Entity.EntityState.Unchanged;
                context.Products.Add(product);
                context.SaveChanges();
            }
        }
        public void UpdateProduct(Product product)
        {
            using (var context = new CBContext())
            {
                context.Entry(product).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteProduct(int ID)
        {
            using (var context = new CBContext())
            {
                // context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var product = context.Products.Find(ID);
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
