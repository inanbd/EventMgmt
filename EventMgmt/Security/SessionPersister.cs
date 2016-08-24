using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

namespace EventMgmt.Security
{
    public static class SessionPersister
    {
        static string usernameSessionVar = "username";
        static string typeSessionVar = "SessionType";

            

        public static User user{
            set {
                HttpContext.Current.Session["user"] = value;
            }

            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionVar = HttpContext.Current.Session["user"];
                if (sessionVar != null)
                {
                    return sessionVar as User;
                }

                return null;
            }
        }


        public static string Type
        {
            set { HttpContext.Current.Session[typeSessionVar] = value; }


            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[typeSessionVar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }

                return null;
            }

        }
        public static string Username
        {
            set
            {
                HttpContext.Current.Session[usernameSessionVar] = value;
            }
            get
            {
                if (HttpContext.Current == null)
                {
                    return string.Empty;
                }
                var sessionVar = HttpContext.Current.Session[usernameSessionVar];
                if (sessionVar != null)
                {
                    return sessionVar as string;
                }

                return null;
            }
        }


    }
}