using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkSample.Models.Restaurants
{
    public class RestaurantListVM
    {
        public List<Restaurant> Restaurants { get; set; }
    }
}