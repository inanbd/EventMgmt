using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventMgmt.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Admin()
        {
            return View();
        }
        public ActionResult Customer()
        {
            return View();
        }
    }
}