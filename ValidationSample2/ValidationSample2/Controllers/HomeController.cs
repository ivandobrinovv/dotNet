using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationSample2.Models.Home;

namespace ValidationSample2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ItemModel model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.ErrorMessage = "Model is not valid";
            }

            return View("Index");
        }
    }
}