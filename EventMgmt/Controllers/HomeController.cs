﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EventMgmt.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        [AllowAnonymous]
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AccessDenied()
        {
            Response.StatusCode = 403;
            return View();
        }
        public ActionResult ItemNotFound()
        {
            Response.StatusCode = 403;
            return View();
        }
        public ActionResult CreateAnEvent()
        {
            Response.StatusCode = 403;
            return View();
        }
        

    }
}