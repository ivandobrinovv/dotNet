using Entities;
using EntityFrameworkSample2.Models.Category;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntityFrameworkSample2.Controllers
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
            CategoryListVM model = new CategoryListVM
            {
                Categories = CategoryRepository.GetAll()
            };

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CategoryVM model)
        {
            Category category = new Category
            {
                Name = model.Name
            };

            CategoryRepository.Create(category);

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if(!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            Category category = CategoryRepository.GetById(id.Value);
            CategoryVM model = new CategoryVM
            {
                ID = category.ID,
                Name = category.Name
            };

            return View(model);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            Category category = CategoryRepository.GetById(id.Value);
            CategoryVM model = new CategoryVM
            {
                ID = category.ID,
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CategoryVM model)
        {
            if(string.IsNullOrWhiteSpace(model.Name))
            {
                return RedirectToAction("Edit", new { id = model.ID });
            }
            Category category = new Category
            {
                ID = model.ID,
                Name = model.Name
            };
            CategoryRepository.Update(category);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }

            Category category = CategoryRepository.GetById(id.Value);
            CategoryVM model = new CategoryVM
            {
                ID = category.ID,
                Name = category.Name
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            CategoryRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}