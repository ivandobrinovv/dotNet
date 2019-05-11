using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EntityFrameworkSample2.Models.Category
{
    public class CategoryListVM
    {
        public List<Entities.Category> Categories { get; set; }
    }
}