//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Restaurants.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Restaurant
    {
        public int RestaurantID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public int CategoryID { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual City City { get; set; }
    }
}
