
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
    public class CategoryController : Controller
    {
        // GET: Category
        public ActionResult Index()
        {
            // if there are some notification message from other views, then set them in the viewbag
            // so that we display them in the screen
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            ViewBag.Message = TempData["Message"];

            // get all categories from the DB
            CategoryRepository categoryRepository = new CategoryRepository();
            List<Category> allCategories = categoryRepository.GetAll();

            // initialize the model for the View
            List<CategoryViewModel> model = new List<CategoryViewModel>();

            // convert all Category objects to ViewModel objects
            foreach (Category category in allCategories)
            {
                CategoryViewModel newItem = new CategoryViewModel();
                newItem.Name = category.Name;
                newItem.ID = category.ID;
                model.Add(newItem);
            }

            return View(model);
        }

        public ActionResult Edit(int id = 0)
        {
            // get the Category to edit
            CategoryRepository categoryRepository = new CategoryRepository();
            Category category = categoryRepository.GetByID(id);

            CategoryViewModel model = new CategoryViewModel();
            if (category != null)
            {
                // create the viewModel from the Category
                model = new CategoryViewModel();
                model.Name = category.Name;
                model.ID = category.ID;
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryEdit)
        {
            // find the Category in the DB
            CategoryRepository categoryRepository = new CategoryRepository();
            Category dbCategory = categoryRepository.GetByID(categoryEdit.ID);

            if (dbCategory == null)
            {
                dbCategory = new Category();
            }

            // update the DB object from the viewModel 
            dbCategory.Name = categoryEdit.Name;
            // no need to update the ID: dbCategory.ID = categoryEdit.ID;
            categoryRepository.Save(dbCategory);

            TempData["Message"] = "The category was saved successfully";
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            CategoryRepository categoryRepository = new CategoryRepository();
            bool isDeleted = categoryRepository.DeleteByID(id);

            if (isDeleted == false)
            {
                TempData["ErrorMessage"] = "Could not find a category with ID = " + id;
            }
            else
            {
                TempData["Message"] = "The record was deleted successfully";
            }

            return RedirectToAction("Index");
        }
    }
}