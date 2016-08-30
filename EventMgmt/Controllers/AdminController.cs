using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMgmt.Security;
using DAL;
namespace EventMgmt.Controllers
{
    
    [CustomAuthorize(Roles ="admin")]
    public class AdminController : Controller
    {
        EMDbContext db;
       
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
        
    }
}