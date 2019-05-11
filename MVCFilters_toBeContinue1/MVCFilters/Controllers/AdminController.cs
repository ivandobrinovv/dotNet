using MVCFilters.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilters.Controllers
{
    //[CustomAuthorize]
    public class AdminController : Controller
    {
        // GET: Admin
        
        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(800);
            return View();
        }
        public ActionResult CrashLink()
        {
            throw new Exception("Crash link is not working!");
            //return View();
        }
    }
}