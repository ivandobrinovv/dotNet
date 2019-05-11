using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormLogin42.Helpers
{
    public class LoginUserSession
    {
        public int UserID { get; private set; }
        public string Username { get; private set; }
        public bool IsAuthenticated { get; private set; }
        public bool IsAdministrator { get; private set; }

        private LoginUserSession()
        {   // IsAuthenticated = false;  
        }

        public static LoginUserSession Current
        {
            get
            {
                // get the LoginUserSession object in the session and if it is null -> create new object and set it in the session
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
            this.UserID = userID;
            this.Username = username;
        }

        public void Logout()
        {
            // set the property values to default values
            // and the most important one is IsAuthenticated = false
            this.IsAuthenticated = false;
            this.IsAdministrator = false;
            this.UserID = 0;
            this.Username = string.Empty;
        }

    }
}