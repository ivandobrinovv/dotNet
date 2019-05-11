using EntityFrameworkSample.Models.Cities;
using Repositories;
using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample.Controllers
{
    public class CityController : Controller
    {
        private readonly CityRepository CityRepository;

        public CityController()
        {
            CityRepository = new CityRepository();
        }

        public ActionResult Index()
        {
            CityListVM model = new CityListVM();
            model.Cities = CityRepository.GetAll();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            City city = CityRepository.GetByID(id.Value);

            if (city == null) return RedirectToAction("Index");

            return View(city);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            City city = CityRepository.GetByID(id.Value);

            if (city == null) return RedirectToAction("Index");

            return View(city);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            CityRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(City city)
        {
            if (city == null || string.IsNullOrWhiteSpace(city.Name))
            {
                return RedirectToAction("Index");
            }

            CityRepository.Create(city);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            City city = CityRepository.GetByID(id.Value);

            return View(city);
        }

        [HttpPost]
        public ActionResult Edit(City city)
        {
            if (city == null || string.IsNullOrWhiteSpace(city.Name))
            {
                return RedirectToAction("Index");
            }

            CityRepository.Update(city);

            return RedirectToAction("Index");
        }
    }
}