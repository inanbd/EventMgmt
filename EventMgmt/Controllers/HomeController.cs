using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMgmt.Security;

namespace EventMgmt.Controllers
{
    public class HomeController : Controller
    {
        
       [CustomAuthorize(Roles ="admin")]
        public ActionResult Admin()
        {
            Session["Username"] = "admin";
            return View();
        }

        [CustomAuthorize(Roles = "customer")]
        public ActionResult Customer()
        {
            ViewBag.message = SessionPersister.Username;
            return View();
        }
    }
}