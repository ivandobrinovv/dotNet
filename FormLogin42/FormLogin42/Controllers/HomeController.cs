using FormLogin42.Helpers;
using FormLogin42.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormLogin42.Controllers
{
# region mockup classes
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public bool IsAdministrator { get; set; }
    } 

    public class UserRepository
    {
        public User GetUserByNameAndPassword(string username, string password)
        {
            if (username == "Ivan")
            {
                return null;
            }
            else
            {
                return new User() { ID = 2, Username = username, IsAdministrator = true };
            }
            
        }
    }

#endregion


    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Login")]
        public ActionResult LoginPost(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                // here we have to check if the username exists in the database
                UserRepository userRepository = new UserRepository();
                User dbUser = userRepository.GetUserByNameAndPassword(loginViewModel.Username, loginViewModel.Password);

                bool isUserExists = dbUser != null;
                if (isUserExists)
                {
                    LoginUserSession.Current.SetCurrentUser(dbUser.ID, dbUser.Username, dbUser.IsAdministrator);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid username and/or password");
                }
            }
            // if we are here, this means there is some validation error and we have to show the login screen again
            return View();

        }


        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Index");
        }
    }
}