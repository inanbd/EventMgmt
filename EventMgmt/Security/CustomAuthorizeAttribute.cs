using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using DAL;
namespace EventMgmt.Security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {



        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (string.IsNullOrEmpty(SessionPersister.Username))
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Account", action = "Index" }
                    ));

            }
            else
            {
                CustomPrincipal mp = new CustomPrincipal(SessionPersister.user);
                if (!mp.IsInRole(Roles))
                {
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(
                    new { controller = "Account", action = "AccessDenied" }
                    ));
                }
            }
        }



    }
}