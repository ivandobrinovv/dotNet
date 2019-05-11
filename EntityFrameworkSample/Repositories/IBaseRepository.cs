using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBaseRepository <T> where T : BaseEntity
    {
        List<T> GetAll();

        T GetByID(int id);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
