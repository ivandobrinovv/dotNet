using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository_old
    {
        private RestaurantsEntities Context;

        public CategoryRepository_old()
        {
            Context = new RestaurantsEntities();
        }

        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
            
        }
        public Category GetByID(int id)
        {
            return Context.Categories.Find(id);
        }
        public void Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }
        public void Update(Category category)
        {
            var local = Context.Set<Category>()
                         .Local
                         .FirstOrDefault(f => f.ID == category.ID);
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }
            Context.Entry(category).State = EntityState.Modified;

        //    Context.Entry(category).State = EntityState.Modified;
            //var entry = Context.Entry(category);
            //Context.Categories.Attach(category);
            //entry.State = EntityState.Modified;
            Context.SaveChanges();
        }
        public void DeleteByID(int id)
        {
            Category dbCategory = Context.Categories.Find(id);
            if (dbCategory != null)
            {
                Context.Categories.Remove(dbCategory);
                Context.SaveChanges();
            }
        }
    }
}
