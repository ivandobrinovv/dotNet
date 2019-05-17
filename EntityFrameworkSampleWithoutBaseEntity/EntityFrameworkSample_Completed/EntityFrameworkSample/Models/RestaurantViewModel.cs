using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using System.IO;
using EntityFrameworkSample.Helpers;

namespace EntityFrameworkSample.Models
{
    public class RestaurantViewModel
    {
        #region Properties
        public int ID { get; set; }
        public int CategoryID { get; set; }
        public int CityID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }
        public System.DateTime DateCreated { get; set; }
        public string Email { get; set; }

        public string CategoryName { get; set; }
        public string CityName { get; set; }
        public bool HasImage { get; set; }
        public string ImagePath { get; set; }
        #endregion

        #region Constructors

        public RestaurantViewModel()
        {
        }
        public RestaurantViewModel(Restaurant dbRestaurant)
        {
            this.CategoryID = dbRestaurant.CategoryID;
            this.CategoryName = dbRestaurant.Category.Name;
            this.CityID = dbRestaurant.CityID;
            this.CityName = dbRestaurant.City.Name;
            this.Name = dbRestaurant.Name;
            this.DateCreated = dbRestaurant.DateCreated;
            this.Description = dbRestaurant.Description;
            this.Email = dbRestaurant.Email;
            this.ID = dbRestaurant.ID;
            this.ImageName = dbRestaurant.ImageName;

            this.HasImage = string.IsNullOrEmpty(dbRestaurant.ImageName) == false;
            if (this.HasImage)
            {
                this.ImagePath = Path.Combine(Constants.ImagesDirectory, this.ImageName);
            }
        }
        #endregion
    }
}