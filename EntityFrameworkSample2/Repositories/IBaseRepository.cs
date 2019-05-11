using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        List<T> GetAll();

        T GetById(int id);

        void Create(T entity);

        void Delete(int id);

        void Update(T entity);
    }
}
