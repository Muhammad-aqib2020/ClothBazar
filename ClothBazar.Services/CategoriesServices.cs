using ClothBazar.Database;
using ClothBazar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClothBazar.Services
{
   public class CategoriesServices
    {
        public Category GetCategory(int ID)
        {
            using (var context = new CBContext())
            {
                return context.categories.Find(ID);
            }
        }

        public List<Category> GetCategories()
        {
            
            using (var context=new CBContext())
            {
                return context.categories.ToList();
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
