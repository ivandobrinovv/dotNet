using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.DataAccess.Repositories
{
    public class BaseRepository
    {
        protected string ConnectionString;

        public BaseRepository()
        {
            // Note: usually the connection string has to be stored in app.config or Web.config file
            ConnectionString = @"Data Source=DESKTOP-B729H6V\SQLEXPRESS;Initial Catalog=RestaurantsDB;Integrated Security=True";
        }
    }
}
