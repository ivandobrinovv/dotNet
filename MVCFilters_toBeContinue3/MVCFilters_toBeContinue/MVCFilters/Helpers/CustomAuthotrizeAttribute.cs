using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVCFilters.Helpers
{
    public class CustomAuthotrizeAttribute : FilterAttribute, IAuthorizationFilter
    {
        public bool AllowAccessToUser;
        public void OnAuthorization(AuthorizationContext filterContext)
        {
            if (filterContext.ActionDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any()
                ||
                filterContext.ActionDescriptor.ControllerDescriptor.GetCustomAttributes(typeof(AllowAnonymousAttribute), true).Any())
            {
                return;
            }

            //check if the currens session is not authenticated - then redirect to login
            if (LoginUserSession.Current.IsAuthenticated == false)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { controller = "Home", action = "Login" })
                    );
            }
            if (AllowAccessToUser == false && LoginUserSession.Current.IsAdministrator == false)
            {
                filterContext.Result = new ViewResult { ViewName ="AccessDenied"};
            }
        }
    }
}