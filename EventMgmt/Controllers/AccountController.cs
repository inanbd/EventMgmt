using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMgmt.Models;
using DAL;
using System.Web.Security;
using EventMgmt.Security;

namespace EventMgmt.Controllers
{

    [AllowAnonymous]
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

       
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel userinfo)
        {

            using(EMDbContext db = new EMDbContext())
            {
                User user = db.Users.Where(x => x.UserName == userinfo.Username && x.Password == userinfo.Password).SingleOrDefault();

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.UserName, false);
                    SessionPersister.user = user;
                    if (user.UserType.Equals("admin"))
                    {
                        return RedirectToAction("Index","Admin");

                    }else if (user.UserType.Equals("customer"))
                    {
                        return RedirectToAction("Index", "Customer");
                    }
                    else
                    {
                        ViewBag.Message = "Invalid User";
                    }

                }
                else
                {
                    ViewBag.Message = "Invalid Username/Password";
                }
                

            }



            return View();
        }



        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User NewUser)
        {
            if (ModelState.IsValid)
            {
                using (EMDbContext db = new EMDbContext())
                {
                    NewUser.UserType = "customer";
                    db.Users.Add(NewUser);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = NewUser.FirstName + " " + NewUser.LastName + ",Your Account has Successfully Registered.";

            }
            return View();
        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            SessionPersister.user = null;
            return RedirectToAction("Index","Home");
            
        }

    }
}