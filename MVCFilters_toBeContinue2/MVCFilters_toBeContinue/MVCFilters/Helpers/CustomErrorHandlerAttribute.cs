using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCFilters.Helpers
{
    public class CustomErrorHandlerAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            //log the exception to a log file

            //redirect to the ServerError.cshtml view
            filterContext.Result = new ViewResult { ViewName= "ServerError" };
            (filterContext.Result as ViewResult).ViewBag.Errormessage = filterContext.Exception.Message;

            //it is important to mark the exception as handled
            filterContext.ExceptionHandled = true;

            //this is not needed, just add it for better understanding
            filterContext.HttpContext.Response.Clear();
            filterContext.HttpContext.Response.StatusCode = 500;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
        }
    }
}