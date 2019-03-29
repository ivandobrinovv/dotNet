using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.DataAccess.Entities
{
    public class Restaurant
    {
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public int CityID { get; set; }
        public string CityName { get; set; }
        public string Name { get; set; }
    }
}
