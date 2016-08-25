using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace EventMgmt.Security
{
    public static class SessionPersister
    {
        static string userSessionvar = "userSessionVar";

        public static User user
        {
            set
            {
                HttpContext.Current.Session[userSessionvar] = value;
            }

            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionVar = HttpContext.Current.Session[userSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as User;
                }

                return null;
            }
        }

    }
}