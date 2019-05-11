using DataAccess;
using HashPasswordCustomValidation.Helpers;
using MVCHashPasswordAndCustomValidator1.Models;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCHashPasswordAndCustomValidator1.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            ViewBag.ErrorMessage = TempData["ErrorMessage"];

            //ToDo
            return View();
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegistrationViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                UserRepository userRepository = new UserRepository();
                //check if the user already exists in the DB
                User existingDbUser = userRepository.GetUserByName(viewModel.Username);
                if (existingDbUser != null)
                {
                    ModelState.AddModelError("","This user is already registered in the system!");
                    return View();
                }

                User dbUser = new DataAccess.User();
                dbUser.Username = viewModel.Username;

                //save the user to the DB
                userRepository.RegisterUser(dbUser, viewModel.Password);

                TempData["Message"] = "User was registered successfully";
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }            
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //here we have to check if the username exists in the DB
                UserRepository userRepository = new UserRepository();
                User dbUser = userRepository.GetUserByNameAndPassword(viewModel.Username, viewModel.Password);

                bool isUserExists = dbUser != null;
                if (isUserExists)
                {
                    LoginUserSession.Current.SetCurrentUser(dbUser.ID, dbUser.Username, false);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","Invalid username and/or password!");
                }
            }
           
            return View();                      
        }

        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Index");
        }
    }
}