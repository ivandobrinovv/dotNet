using EntityFrameworkSample.Models.Restaurants;
using Repositories;
using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly RestaurantRepository _restaurantRepository;
        private readonly CategoryRepository _categoryRepository;
        private readonly CityRepository _cityRepository;

        public RestaurantController()
        {
            _restaurantRepository = new RestaurantRepository();
            _categoryRepository = new CategoryRepository();
            _cityRepository = new CityRepository();
        }

        public ActionResult Index()
        {
            RestaurantListVM model = new RestaurantListVM
            {
                Restaurants = _restaurantRepository.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            var categories = _categoryRepository.GetAll();
            var cities = _cityRepository.GetAll();

            RestaurantCreateVM model = new RestaurantCreateVM();

            PrepareDropdowns(model.Categories, model.Cities, categories, cities);

            return View(model);
        }

        [HttpPost]
        public ActionResult Create(RestaurantCreateVM model)
        {
            Restaurant restaurant = new Restaurant
            {
                Name = model.Name,
                CategoryID = model.CategoryID,
                CityID = model.CityID
            };

            _restaurantRepository.Create(restaurant);

            return RedirectToAction("Index");
        }

        private void PrepareDropdowns(List<SelectListItem> categories,
                                      List<SelectListItem> cities,
                                      List<Category> allCategories,
                                      List<City> allCities)
        {
            foreach(var city in allCities)
            {
                var item = new SelectListItem
                {
                    Text = city.Name,
                    Value = city.ID.ToString()
                };

                cities.Add(item);
            }

            foreach (var category in allCategories)
            {
                var item = new SelectListItem
                {
                    Text = category.Name,
                    Value = category.ID.ToString()
                };

                categories.Add(item);
            }
        }
    }
}