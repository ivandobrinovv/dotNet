using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using EntityFrameworkSample.Helpers;
using System.IO;

namespace EntityFrameworkSample.Models
{
    public class SearchViewModel
    {
        #region Properties
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantDescription { get; set; }
        public string RestaurantImageUrl { get; set; }
        public string CityName { get; set; }
        public string CategoryName { get; set; }

        public bool HasImage { get; set; }
        #endregion

        #region Constructors
        public SearchViewModel(Restaurant dbRestaurant)
        {
            this.RestaurantID = dbRestaurant.ID;
            this.RestaurantName = dbRestaurant.Name;
            this.RestaurantDescription = dbRestaurant.Description;

            // ! Important - notice how we get the City Name (lazy loading)
            this.CityName = dbRestaurant.City.Name;

            // ! Important - notice how we get the Category Name (lazy loading)
            this.CategoryName = dbRestaurant.Category.Name;

            // we have to check if the image exists, otherwise the UI crashes if there is no valid image 
            if (string.IsNullOrEmpty(dbRestaurant.ImageName) == false)
            {
                this.HasImage = true;
                string imageFullPath = Path.Combine(Constants.ImagesDirectory, dbRestaurant.ImageName);
                this.RestaurantImageUrl = imageFullPath;
            }
        }
        #endregion
    }
}