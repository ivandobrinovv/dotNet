using MVCFilters.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilters.Controllers
{
    [CustomAuthotrize]
    public class AdminController : Controller
    {
        // GET: Admin
        //[CustomAuthotrize]
        public ActionResult Index()
        {
            return View();
        }
    }
}