using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMgmt.Security;

namespace EventMgmt.Controllers
{

    [CustomAuthorize(Roles = "customer")]
    public class CustomerController : Controller
    {
        
        // GET: Customer
        public ActionResult Index()
        {
            return View();
        }
    }
}