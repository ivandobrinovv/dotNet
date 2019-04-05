using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class CategoryRepository
    {
        private RestaurantsDBEntities Context;

        public CategoryRepository()
        {
            Context = new RestaurantsDBEntities();
        }

        public List<Category> GetAll()
        {
            return Context.Categories.ToList();
        }

        public Category GetByID(int id)
        {
            //return Context.Categories
            //              .FirstOrDefault(c => c.CategoryID == id);

            return Context.Categories.Find(id);
        }

        public void Create(Category category)
        {
            Context.Categories.Add(category);
            Context.SaveChanges();
        }

        public void Update(Category category)
        {
            Category categoryToEdit = Context.Categories.FirstOrDefault(c => c.CategoryID == category.CategoryID);
            if (categoryToEdit != null)
            {
                categoryToEdit.Name = category.Name;
                Context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Category category = GetByID(id);
            if (category != null)
            {
                Context.Categories.Remove(category);
                Context.SaveChanges();
            }
        }
    }
}
