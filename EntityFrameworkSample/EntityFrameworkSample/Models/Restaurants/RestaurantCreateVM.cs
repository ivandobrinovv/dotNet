using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample.Models.Restaurants
{
    public class RestaurantCreateVM
    {
        public string Name { get; set; }

        public int CategoryID { get; set; }

        public int CityID { get; set; }

        public List<SelectListItem> Categories { get; set; } = new List<SelectListItem>();

        public List<SelectListItem> Cities { get; set; } = new List<SelectListItem>();
    }
}