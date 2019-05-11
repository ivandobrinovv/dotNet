using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilters.Helpers
{
    public class CustomActionFilterAttribute : FilterAttribute, IActionFilter
    {

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Items.Add("StartTime",DateTime.Now.Ticks);
            System.Threading.Thread.Sleep(1);
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            long startTime = (long)filterContext.HttpContext.Items["StartTime"];
            TimeSpan period = new TimeSpan(DateTime.Now.Ticks - startTime);
            string duration = string.Format("{0}s {1}ms",period.Seconds,period.Milliseconds);
            filterContext.Controller.ViewBag.Period = duration;
        }

        
    }
}