using Restaurants.DataAccess.Entities;
using Restaurants.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurants.Console
{
	class Program
	{
		static void Main(string[] args)
		{
            // get all cities
            CategoryRepository categoryRepository = new CategoryRepository();
			CityRepository cityRepository = new CityRepository();
			List<City> cities = cityRepository.GetAll();
			System.Console.WriteLine("The cities are: ");
			foreach (City item in cities)
			{
				System.Console.WriteLine(item.Name);
			}

			System.Console.WriteLine();

			// search city by ID
			City city = cityRepository.GetByID(1);
			System.Console.Write("The city with id=1 is: ");
			if (city != null)
			{
				System.Console.WriteLine(city.Name);
			}
			else
			{
				System.Console.WriteLine("not found");
			}

			System.Console.WriteLine();

			// get all restaurants
			RestaurantRepository restaurantRepository = new RestaurantRepository();
			List<Restaurant> restaurants = restaurantRepository.GetAll();
			System.Console.WriteLine("The restaurants are: ");
			foreach (Restaurant item in restaurants)
			{
				string line = string.Format($"{item.Name} - {item.CityName} - {item.CategoryName}");
				System.Console.WriteLine(line);
			}

			System.Console.WriteLine();

            // get all restaurants from the city with id = 1
            string cityName = cityRepository.GetByID(1).Name;
			restaurants = restaurantRepository.GetByCityID(1);
			System.Console.WriteLine($"The restaurants from {cityName} are: ");
			foreach (Restaurant item in restaurants)
			{
				string line = string.Format("{0} - {1} - {2}", item.Name, item.CityName, item.CategoryName);
				System.Console.WriteLine(line);
			}

			System.Console.WriteLine();

			// insert new restaurant
			Restaurant newRestaurant = new Restaurant();
			newRestaurant.Name = "new restaurant";
			newRestaurant.CategoryID = 1;
			newRestaurant.CityID = 2;
			restaurantRepository.Create(newRestaurant);

			System.Console.WriteLine();

			restaurantRepository.DeleteByID(newRestaurant.ID);

            System.Console.WriteLine($"The category with ID = 1 is : {categoryRepository.GetByID(1).Name}"); 

			System.Console.Read();
		}
	}
}
