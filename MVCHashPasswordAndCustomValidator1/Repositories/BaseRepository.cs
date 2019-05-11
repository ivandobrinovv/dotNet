﻿using DataAccess;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T: class
    {
        protected HashPasswordKn1DBEntities Context;

        public BaseRepository()
        {
            //this constructor is authomatically invoked when the default child constructor is called.
            Context = new HashPasswordKn1DBEntities();
        }

        protected DbSet<T> DbSet
        {
            get
            {
                return Context.Set<T>();
            }
        }

        

        public List<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }

        public void Create(T item)
        {
            Context.Set<T>().Add(item);
            Context.SaveChanges();
        }
                

        public void Update(T item, Func<T, bool> findByIDPredicate)
        {
            var local = Context.Set<T>()
                .Local
                .FirstOrDefault(findByIDPredicate);// (f=>f.ID==item.ID)
            if (local != null)
            {
                Context.Entry(local).State = EntityState.Detached;
            }
            Context.Entry(item).State = EntityState.Modified;

            Context.SaveChanges();
        }

        public bool DeleteByID(int id)
        {
            bool isDeleted = false;
            T dbItem = Context.Set<T>().Find(id);
            if (dbItem != null)
            {
                Context.Set<T>().Remove(dbItem);
                int recordsChanged = Context.SaveChanges();
                isDeleted = recordsChanged > 0;
            }
            return isDeleted;
        }

        //this method has to be written in all inhereted classes
        public abstract void Save(T item);
        
    }
}
