using EntityFrameworkSample.Models.Categories;
using Repositories;
using Restaurants.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryRepository CategoryRepository;

        public CategoryController()
        {
            CategoryRepository = new CategoryRepository();
        }

        public ActionResult Index()
        {
            CategoryListVM model = new CategoryListVM();
            model.Categories = CategoryRepository.GetAll();

            return View(model);
        }

        public ActionResult Details(int? id)
        {
            if(id == null) return RedirectToAction("Index");

            Category category = CategoryRepository.GetByID(id.Value);

            if (category == null) return RedirectToAction("Index");

            return View(category);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            Category category = CategoryRepository.GetByID(id.Value);

            if (category == null) return RedirectToAction("Index");

            return View(category);
        }
        
        [HttpPost]
        public ActionResult Delete(int id)
        {
            CategoryRepository.Delete(id);

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Category category)
        {
            if(category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                return RedirectToAction("Index");
            }

            CategoryRepository.Create(category);

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int? id)
        {
            if (id == null) return RedirectToAction("Index");

            Category category = CategoryRepository.GetByID(id.Value);

            return View(category);
        }

        [HttpPost]
        public ActionResult Edit(Category category)
        {
            if (category == null || string.IsNullOrWhiteSpace(category.Name))
            {
                return RedirectToAction("Index");
            }

            CategoryRepository.Update(category);

            return RedirectToAction("Index");
        }
    }
}