﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using EventMgmt.Security;

namespace EventMgmt.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
         
            return View();
        }
        [HttpPost]
        public ActionResult Index(Login user)
        {

            //SessionPersister.Username = user.UserName;
            
            if (string.IsNullOrEmpty(user.UserName) || string.IsNullOrEmpty(user.Password))
            {
                return View();
            }
            using (EMDbContext db = new EMDbContext())
            {
                var usr = db.Users.SingleOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
                if (usr != null)
                {
                    SessionPersister.Username = user.UserName;
                    SessionPersister.user = usr;
                    SessionPersister.Type = usr.UserType;
                   
                    if (usr.UserType.ToString().Equals("admin"))
                    {
                        
                        Response.Redirect("/Home/Admin",false);

                    }
                    else if (usr.UserType.ToString().Equals("customer"))
                    {
                       
                        Response.Redirect("/Home/Customer",false);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Something is wrong..We are gonna fix this soon.");
                        Console.WriteLine("invalid type request from IP: " + Request.UserHostAddress);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "Invalid Username/Password");
                }
            }
           
            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                using (EMDbContext db = new EMDbContext())
                {
                    user.UserType = "customer";
                    db.Users.Add(user);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = user.FirstName + " " + user.LastName + ",Your Account has Successfully Registered.";

            }
            return View();
        }
        public ActionResult Logout()
        {
            Session.Remove("Username");
            Session.Remove("Usertype");
            return View("Index");
        }
        public ActionResult AccessDenied()
        {
            return View();
        }

    }
}