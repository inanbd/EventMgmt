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
        [HttpGet]
        public ActionResult ManageFood()
        {
            EMDbContext context = new EMDbContext();
            List<Food> foods = context.Foods.ToList();
            return View(foods);
        }


        /* 
         [CustomAuthorize(Roles = "admin")]
         [HttpGet]
         public ActionResult ManageFood(int id)
         {
             EMDbContext context = new EMDbContext();
             Food food = context.Foods.SingleOrDefault(d => d.FoodId == id);
             return View(food);
         }

         [CustomAuthorize(Roles = "admin")]
         [HttpPost]
         public ActionResult ManageFood([Bind(Exclude="FoodId")] Food food)
         {
             EMDbContext context = new EMDbContext();
             Food foodupdate = context.Foods.SingleOrDefault(d => d.FoodId == food.FoodId);
             foodupdate.FoodTitle = food.FoodTitle;
             foodupdate.FoodCategory = food.FoodCategory;
             foodupdate.FoodDescription = food.FoodDescription;
             foodupdate.FoodCost = food.FoodCost;
             context.SaveChanges();

             return RedirectToAction("Index");
         }*/

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
        [HttpGet]
        public ActionResult EditFood(int id)
        {
            EMDbContext context = new EMDbContext();
            Food food = context.Foods.SingleOrDefault(d => d.FoodId == id);
            return View(food);
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult EditFood([Bind(Include = "FoodId,FoodTitle,FoodCategory,FoodCost")] Food food)
        {
            if (ModelState.IsValid)
            {
                using (EMDbContext context = new EMDbContext())
                {
                    context.Entry(food).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

            }
            /*EMDbContext context = new EMDbContext();

            Food foodupdate = context.Foods.SingleOrDefault(d => d.FoodId == food.FoodId);
            foodupdate.FoodTitle = food.FoodTitle;
            foodupdate.FoodCategory = food.FoodCategory;
            foodupdate.FoodDescription = food.FoodDescription;
            foodupdate.FoodCost = food.FoodCost;
            context.SaveChanges();

            */

            return RedirectToAction("Index");
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult DeleteFood(int id)
        {
            EMDbContext context = new EMDbContext();
            Food food = context.Foods.SingleOrDefault(d => d.FoodId == id);
            return View(food);
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteFood_Post(int id)
        {
            EMDbContext context = new EMDbContext();
            Food foodToDel = context.Foods.SingleOrDefault(d => d.FoodId == id);
            context.Foods.Remove(foodToDel);
            context.SaveChanges();

            //return RedirectToAction("Delete", "ManageFood");
            return RedirectToAction("ManageFood");
        }

        /*
         [HttpGet]
        public ActionResult Delete(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            Department dept = context.Departments.SingleOrDefault(d => d.DepartmentId == id);
            return View(dept);
        }

        [HttpPost][ActionName("Delete")]
        public ActionResult Delete_Post(int id)
        {
            EmployeeDBContext context = new EmployeeDBContext();
            Department depttodel = context.Departments.SingleOrDefault(d => d.DepartmentId == id);
            context.Departments.Remove(depttodel);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
         */


        [CustomAuthorize(Roles = "admin")]
        public ActionResult AddCatering()
        {
            return View();
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpGet]
        public ActionResult ManageCatering()
        {
            EMDbContext context = new EMDbContext();
            List<Catering> cataring = context.Caterings.ToList();
            return View(cataring);
        }

        [CustomAuthorize(Roles = "admin")]
        [HttpPost]
        public ActionResult AddCatering(Catering catering)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult AddDecoration(Decoration decoration)
        {


            if (ModelState.IsValid)
            {
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
        public ActionResult AddPhotography(Photography photo)
        {
            if (ModelState.IsValid)
            {
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
        public ActionResult AddPlace(Place place)
        {
            if (ModelState.IsValid)
            {
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