using SessionSample3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SessionSample3.Helpers
{
    public class SessionObjects
    {
        public static List<User> Users
        {
            get
            {
                if(HttpContext.Current.Session["Users"] == null)
                {
                    HttpContext.Current.Session["Users"] = new List<User>();
                }
                return (List<User>)HttpContext.Current.Session["Users"];
            }
            set
            {
                HttpContext.Current.Session["Users"] = value;
            }
        }
    }
}