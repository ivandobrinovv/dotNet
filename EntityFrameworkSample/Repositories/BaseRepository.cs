using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly RestaurantsDBEntities Context;

        public BaseRepository()
        {
            Context = new RestaurantsDBEntities();
        }

        public void Create(T entity)
        {
            Context.Set<T>().Add(entity);
            Context.SaveChanges();
        }

        public void Delete(int id)
        {
            T entity = GetByID(id);

            if (entity == null) throw new ArgumentException();

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            T itemFromDB = Context.Set<T>().FirstOrDefault(t => t.ID == entity.ID);

            if (itemFromDB == null) throw new ArgumentException();

            Context.Entry(itemFromDB).State = EntityState.Detached;
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
        }
    }
}
