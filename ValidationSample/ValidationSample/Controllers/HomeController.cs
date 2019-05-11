using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ValidationSample.Models.Home;

namespace ValidationSample.Controllers
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
                ViewBag.Error = "Error message";
            }
            return View("Index");
        }
    }
}