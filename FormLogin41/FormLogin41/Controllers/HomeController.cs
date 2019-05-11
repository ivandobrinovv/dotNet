using FormLogin41.Helpers;
using FormLogin41.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormLogin41.Controllers
{
    #region mockup classes
    //This code is only for testing
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public bool IsAdministrator { get; set; }
    }
    public class UserRepository
    {
        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return new User() { ID = 2, Username = username, IsAdministrator = true };
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
        public ActionResult LoginPost(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                //
                UserRepository userRepository = new UserRepository();
                User dbUser = userRepository.GetUserByUsernameAndPassword(viewModel.Username,viewModel.Password);

                bool isUserExists = dbUser != null;
                if (isUserExists)
                {
                    LoginUserSession.Current.SetCurrentUser(dbUser.ID, dbUser.Username, dbUser.IsAdministrator);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("","Invalid username and/or password!");
                }
            }
            //if we are here, this means there is some validation error
            return View();

        }

        public ActionResult Logout()
        {
            LoginUserSession.Current.Logout();
            return RedirectToAction("Index");
        }
    }
}