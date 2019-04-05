using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkSample.Models.Categories
{
    public class CategoryListVM
    {
        public List<Category> Categories { get; set; }
    }
}