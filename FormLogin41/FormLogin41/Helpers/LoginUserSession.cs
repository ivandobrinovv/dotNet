using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormLogin41.Helpers
{
    public class LoginUserSession
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public bool IsAuthenticated { get; set; }
        public bool IsAdministrator { get; set; }

        private LoginUserSession()
        {
           // IsAuthenticated = false;
        }

        public static LoginUserSession Current
        {
            get
            {
                LoginUserSession loginUserSession = (LoginUserSession)HttpContext.Current.Session["LoginUser"];
                if (loginUserSession == null)
                {
                    loginUserSession = new LoginUserSession();
                    HttpContext.Current.Session["LoginUser"] = loginUserSession;
                }
                return loginUserSession;
            }
        }

        public void SetCurrentUser(int userID, string username, bool isAdministrator)
        {
            this.IsAuthenticated = true;
            this.IsAdministrator = isAdministrator;
            this.UserId = userID;
            this.Username = username;
        }

        public void Logout()
        {
            //set the property values to the default values
            // and the most important one is IsAuthenticated=false
            this.IsAuthenticated = false;
            this.IsAdministrator = false;
            this.Username = string.Empty;
            this.UserId = 0;
        }
    }
}