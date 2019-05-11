using Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly RestaurantsDBEntities Context;

        public BaseRepository()
        {
            Context = new RestaurantsDBEntities();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetById(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = GetById(id);

            if(entity == null)
            {
                throw new ArgumentException();
            }

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public void Update(T entity)
        {
            T itemToEdit = Context.Set<T>()
                             .FirstOrDefault(t => t.ID == entity.ID);

            if(itemToEdit == null)
            {
                throw new ArgumentException();
            }

            Context.Entry(itemToEdit).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
