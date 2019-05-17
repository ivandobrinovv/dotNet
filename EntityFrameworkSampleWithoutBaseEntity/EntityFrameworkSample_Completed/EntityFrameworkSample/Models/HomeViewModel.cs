using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;
using EntityFrameworkSample.Helpers;
using System.IO;

namespace EntityFrameworkSample.Models
{
    public class HomeRestaurantViewModel
    {
        public int ID { get; set; }
        public string ImagePath { get; set; }
    }

    public class HomeViewModel
    {
        #region Properties
        public List<HomeRestaurantViewModel> RestaurantsList { get; set; }
        #endregion

        #region Constructors
        public HomeViewModel()
        {
            // initialize the list with Images; it should not be null
            RestaurantsList = new List<HomeRestaurantViewModel>();
        }

        public HomeViewModel(List<Restaurant> allRestaurants)
            : this()
        {
            foreach (Restaurant restaurant in allRestaurants)
            {
                if (string.IsNullOrEmpty(restaurant.ImageName) == false)
                {
                    string imageFullPath = Path.Combine(Constants.ImagesDirectory, restaurant.ImageName);

                    HomeRestaurantViewModel item = new HomeRestaurantViewModel();
                    item.ID = restaurant.ID;
                    item.ImagePath = imageFullPath;
                    RestaurantsList.Add(item);
                }
            }
        }
        #endregion
    }
}