using DataAccess;
using EntityFrameworkSample.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            RestaurantRepository restaurantRepository = new RestaurantRepository();
            List<Restaurant> allRestaurants = restaurantRepository.GetAll();

            HomeViewModel model = new HomeViewModel(allRestaurants);
            return View(model);
        }

        public ActionResult Search(string searchVal)
        {
            RestaurantRepository restaurantRepository = new RestaurantRepository();
			
			// just in case prevent NullPointerException
            if (searchVal == null)
            {
                searchVal = string.Empty;
            }

            // compare all words to lower case
            searchVal = searchVal.ToLower();

			// use lambda expression to filter the matched objects
            List<Restaurant> foundRestarants = restaurantRepository.GetAll()
                .Where(c => c.Name.ToLower().Contains(searchVal)
                    || c.Description.ToLower().Contains(searchVal))
                .ToList();

			// convert the DB objects to ViewModel objects
            List<SearchViewModel> model = new List<SearchViewModel>();
            foreach (Restaurant dbRestaurant in foundRestarants)
            {
                SearchViewModel modelItem = new SearchViewModel(dbRestaurant);
                model.Add(modelItem);
            }
            
            return View(model);
        }
    }
}