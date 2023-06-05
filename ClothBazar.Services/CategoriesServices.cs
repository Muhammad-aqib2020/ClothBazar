using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;


namespace ClothBazar.Services
{
   public class CategoriesServices
    {
        #region Singleton
        public static CategoriesServices Instance
        {
            get
            {
                if (instance == null) instance = new CategoriesServices();
                
                return instance;
            }
        }
        private static CategoriesServices instance { get; set; }
        private CategoriesServices()
        {

        }
        #endregion
        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {
                return context.categories.Find(ID);
            }
        }
        public int GetCategoriesCount(string search)
        {

            using (var context = new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.categories.Where(p => p.Name != null && p.Name.ToLower()
                   .Contains(search.ToLower())).Count();
                 

                }
                else
                {
                    return context.categories.Count();
                }
            }
        }
        public List<Category> GetCategories(string search,int pageNo)
        {
            //int pageSize = int.Parse(ConfigurationsServices.Instance.GetConfig("ListingPageSize").Value);
            int pageSize = 5;
            using (var context=new CBContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    return context.categories.Where(p => p.Name != null && p.Name.ToLower()
                    .Contains(search.ToLower()))
                    .OrderBy(x => x.ID)
                    .Skip((pageNo - 1) * pageSize)
                    .Take(pageSize)
                    .Include(x => x.Products)
                    .ToList();
                 
                
                }
                else
                {
                    return context.categories.OrderBy(x => x.ID).Skip((pageNo - 1) * pageSize).Take(pageSize).Include(x => x.Products).ToList();
                }
          
            }
        }
        public List<Category> GetAllCategories()
        {
            //int pageSize = int.Parse(ConfigurationsServices.Instance.GetConfig("ListingPageSize").Value);
            using (var context = new CBContext())
            {
              
                    return context.categories.Include(x => x.Products).ToList();
            }
        }

        public List<Category> GetFeaturedCategories()
        {
            using (var context = new CBContext())
            {
                return context.categories.Where(x=>x.IsFeatured && x.ImageURL !=null).ToList();
            }
        }

        public void SaveCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.categories.Add(category);
                context.SaveChanges();
            }
        }
        public void UpdateCategory(Category category)
        {
            using (var context = new CBContext())
            {
                context.Entry(category).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteCategory(int ID)
        {
            using (var context = new CBContext())
            {
                // context.Entry(category).State = System.Data.Entity.EntityState.Deleted;
                var category = context.categories.Find(ID);
                context.categories.Remove(category);
                context.SaveChanges();
            }
        }
    }
}
