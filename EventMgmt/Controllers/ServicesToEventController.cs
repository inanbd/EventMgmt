using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL;
using System.Net;
using System.Data.Entity;

namespace EventMgmt.Controllers
{
    public class ServicesToEventController : Controller
    {
        EMDbContext db;
        Event CurrentEvent;
        // GET: AddService
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult AddService(int? id)
        {
            if (id == null)
            {
                
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                
            }


            
            using(db = new EMDbContext())
            {
                CurrentEvent = db.Events.Find(id);
                if (CurrentEvent == null)
                {
                    return HttpNotFound();
                }

                Security.SessionPersister.Currentevent = CurrentEvent;
                List<Object> model = new List<object>();
                model.Add(db.Foods.ToList());
                model.Add(db.Places.ToList());
                model.Add(db.Decorations.ToList());
                model.Add(db.Photographies.ToList());

                return View(model);
                
            }
            
            
        }
        [HttpPost]
        public ActionResult AddService(int? placeid,int? foodid,int? decid,int? amount)
        {
            if (placeid != null)
            {

                using (db = new EMDbContext())
                {
                    var place = db.Places.Find(placeid);

                    OrderedPlace op = new OrderedPlace()
                    {
                        PlaceCost = place.PlaceCost,
                        PlaceTitle = place.PlaceTitle,
                        PlaceId = place.PlaceId,
                        PlaceDescription = place.PlaceDescription,
                        PlaceCategory = place.PlaceCategory,
                        EventId= Security.SessionPersister.Currentevent.EventId


                    };
                    Security.SessionPersister.Currentevent.OrderedPlaces.Add(op);
                    Security.SessionPersister.Currentevent.TotalCost += (int)op.PlaceCost;
                    db.Entry(Security.SessionPersister.Currentevent).State = EntityState.Modified;
                    db.OPlaces.Add(op);
                    db.SaveChanges();
                    ViewBag.Message = "Place Aaded to your event";

                   
                }

            }
            if (foodid != null)
            {

                using (db = new EMDbContext())
                {
                    var place = db.Foods.Find(foodid);

                    
                    OrderedFood of = new OrderedFood()
                    {
                        FoodCost = place.FoodCost,
                        FoodTitle = place.FoodTitle,
                        FoodId = place.FoodId,
                        FoodDescription = place.FoodDescription,
                        FoodCategory = place.FoodCategory,
                        

                        EventId = Security.SessionPersister.Currentevent.EventId


                    };
                    
                    Security.SessionPersister.Currentevent.OrderedFoods.Add(of);
                    Security.SessionPersister.Currentevent.TotalCost += (int)of.FoodCost;
                    db.Entry(Security.SessionPersister.Currentevent).State = EntityState.Modified;
                    db.OFoods.Add(of);
                    db.SaveChanges();

                    ViewBag.Message = "Food Added to your event";
                }

            }

            using (db = new EMDbContext())
            {
                
                List<Object> model = new List<object>();
                model.Add(db.Foods.ToList());
                model.Add(db.Places.ToList());
                model.Add(db.Decorations.ToList());
                model.Add(db.Photographies.ToList());

                return View(model);

            }



        }

    }
}