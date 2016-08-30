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
        static string EventSessionvar = "evenSessionVar";


        public static Event Currentevent
        {
            set
            {
                HttpContext.Current.Session[EventSessionvar] = value;
            }

            get
            {
                if (HttpContext.Current == null)
                {
                    return null;
                }
                var sessionVar = (Event)HttpContext.Current.Session[EventSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as Event;
                }
                else
                {
                    return null;
                }


            }
        }

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
                    return null as User;
                }
                var sessionVar = (User)HttpContext.Current.Session[userSessionvar];
                if (sessionVar != null)
                {
                    return sessionVar as User;
                }
                else
                {
                    return new User()
                    {
                        UserType="none"
                    };
                }

                
            }
        }
       

    }
}