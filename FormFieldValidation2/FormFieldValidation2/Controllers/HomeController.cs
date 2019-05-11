using FormFieldValidation2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormFieldValidation2.Controllers
{
    public class HomeController : Controller
    {

        

        // GET: Home
        public ActionResult Index()
        {
            //add Message to the ViewBag if another Action has added it to the TempData
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel viewModel)
        {

            //server validation for FirstName to start with capital leter
            if (string.IsNullOrEmpty(viewModel.FirstName) == false)
            {
                char firstLetter = viewModel.FirstName[0];
                if (char.IsUpper(firstLetter) == false)
                {
                    ModelState.AddModelError("FirstName","First name should start with a capital letter!");
                }
            }


            //server validation for banned users
            if (viewModel.FirstName == "Ivan" && viewModel.LastName == "Ivanov")
            {
                ModelState.AddModelError("","Sorry, this user is banned from our web server!");
            }

            //Do not save to database when the ModelState is not valid!
            if(ModelState.IsValid)
            {
                //save the information to the data base
                //...

                TempData["Message"] = "You registered succesfully!";
                return RedirectToAction("Index");

            }
            return View();
        }


        //see AJAX
        //see JSON


        public ActionResult ValidateEmail(string email)
        {
            bool isEmailUsed = false;
            if (string.IsNullOrEmpty(email) == false)
            {
                isEmailUsed = (email == "venelinmonev@gmail.com");
            }
            return Json(!isEmailUsed, JsonRequestBehavior.AllowGet);
        }
    }
}