using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventMgmt.Security;
using DAL;

namespace EventMgmt.Controllers
{

    [Authorize]
    public class ServiceController : Controller
    {
        EMDbContext db2 = new EMDbContext();
        // GET: Event
        public ActionResult Index()
        {
            List<object> models = new List<object>();

            models.Add(db2.Foods.ToList());
            models.Add(db2.Caterings.ToList());
            models.Add(db2.Decorations.ToList());
            models.Add(db2.Places.ToList());
            models.Add(db2.Photographies.ToList());


            return View(models);

        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult Add()
        {
            return View();
        }


        [CustomAuthorize(Roles = "admin")]
        public ActionResult Manage()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        public ActionResult AddFood()
        {
            return View();
        }


        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddFood(Food food, HttpPostedFileBase file)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    food.pic1 = file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/img/") + file.FileName);

                }
                using (EMDbContext db = new EMDbContext())
                {
                    db.Foods.Add(food);
                    db.SaveChanges();
                }


                ModelState.Clear();
                ViewBag.Message = "Service Added.";


            }
            return View();
        }



        [CustomAuthorize(Roles = "admin")]
        public ActionResult AddCatering()
        {
            return View();
        }



        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddCatering(HttpPostedFileBase file, Catering catering)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    catering.pic5 = file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/imgc/") + file.FileName);

                }
                using (EMDbContext db = new EMDbContext())
                {
                    db.Caterings.Add(catering);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Service Added.";
            }
            return View();
        }



        [CustomAuthorize(Roles = "admin")]
        public ActionResult AddDecoration()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddDecoration(HttpPostedFileBase file, Decoration decoration)
        {


            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    decoration.pic4 = file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/imgd/") + file.FileName);

                }
                using (EMDbContext db = new EMDbContext())
                {
                    db.Decorations.Add(decoration);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Service Added.";
            }


            return View();
        }


        [CustomAuthorize(Roles = "admin")]
        public ActionResult AddPhotography()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddPhotography(HttpPostedFileBase file, Photography photo)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    photo.pic2 = file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/imgp/") + file.FileName);

                }
                using (EMDbContext db = new EMDbContext())
                {
                    db.Photographies.Add(photo);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Service Added.";
            }
            return View();
        }



        [CustomAuthorize(Roles = "admin")]
        public ActionResult AddPlace()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddPlace(HttpPostedFileBase file, Place place)
        {
            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    place.pic3 = file.FileName;
                    file.SaveAs(HttpContext.Server.MapPath("~/imgpl/") + file.FileName);

                }
                using (EMDbContext db = new EMDbContext())
                {
                    db.Places.Add(place);
                    db.SaveChanges();
                }
                ModelState.Clear();
                ViewBag.Message = "Service Added.";
            }
            return View();
        }



    }
}