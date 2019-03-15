using SessionSample3.Helpers;
using SessionSample3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionSample3.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View(SessionObjects.Users);
        }

        public ActionResult Details(int id)
        {
            User user =  SessionObjects.Users.FirstOrDefault(u => u.ID == id);
            return View(user);
        }

        public ActionResult Edit(int id)
        {
            User user = SessionObjects.Users.FirstOrDefault(u => u.ID == id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            User userToEdit = SessionObjects.Users.FirstOrDefault(u => u.ID == user.ID);
            if(userToEdit != null)
            {
                userToEdit.Username = user.Username;
                userToEdit.Phonenumber = user.Phonenumber;
            }

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            User user = SessionObjects.Users.FirstOrDefault(u => u.ID == id);
            
            if(user != null)
            {
                SessionObjects.Users.Remove(user);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if(SessionObjects.Users.Count == 0)
            {
                user.ID = 1;
            }
            else
            {
                user.ID = SessionObjects.Users.Select(u => u.ID).Max() + 1;
            }
            SessionObjects.Users.Add(user);

            return RedirectToAction("Index");
        }
    }
}