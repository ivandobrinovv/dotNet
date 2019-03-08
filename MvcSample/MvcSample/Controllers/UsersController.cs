using MvcSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcSample.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            User[] users = new User[]
            {
                new User
                {
                    Name = "Petar",
                    Surename = "Petrov"
                },

                new User
                {
                    Name = "Ivan",
                    Surename = "Petrov"
                },

                new User
                {
                    Name = "Georgi",
                    Surename = "Ivanov"
                },
            };

            return View(users);
        }

        public ActionResult ShowUser()
        {
            User user = new User
            {
                Name = "Sergei",
                Surename = "Simeonov"
            };

            return View(user);
        }
    }
}