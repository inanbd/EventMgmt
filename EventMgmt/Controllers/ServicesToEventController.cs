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

        
        
        public ActionResult DeleteService(int? placeid, int? foodid, int? decid, int? photoid)
        {
            
            if (placeid != null)
            {
                using(db = new EMDbContext())
                {
                    OrderedPlace op = db.OPlaces.Find(placeid);
                    if (op == null)
                    {
                        Response.Redirect("/Home/ItemNotFound", false);
                        return null;
                    }
                    return View("deleteop", op);
                }

                
               
            }
            if (foodid != null)
            {

                using (db = new EMDbContext()) {
                    OrderedFood of = db.OFoods.Find(foodid);
                    if (of == null)
                    {
                        Response.Redirect("/Home/ItemNotFound", false);
                        return null;
                    }
                    return View("deleteof", of);
                }
                
                

            }
            if (decid != null)
            {
                using (db= new EMDbContext())
                {
                    OrderedDecoration od = db.ODecorations.Find(decid);
                    if (od == null)
                    {
                        Response.Redirect("/Home/ItemNotFound", false);
                        return null;
                    }
                    return View("deleteod", od);
                }
                
                

            }
            if (photoid != null)
            {

                using(db= new EMDbContext())
                {
                    OrderedPhotography op = db.OPhotographies.Find(photoid);
                    if (op == null)
                    {
                        Response.Redirect("/Home/ItemNotFound", false);
                        return null;


                    }
                    return View("deletephoto", op);
                }
                
            }
            
            Response.Redirect("/Home/ItemNotFound", false);
            return null;
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? placeid, int? foodid, int? decid, int? photoid)
        {

            using (db = new EMDbContext())
            {
                if (photoid != null)
                {
                    OrderedPhotography op = db.OPhotographies.Find(photoid);
                        db.OPhotographies.Remove(op);
                        db.SaveChanges();
                    
                }
                if (decid != null)
                {
                    OrderedDecoration od = db.ODecorations.Find(decid);
                    db.ODecorations.Remove(od);
                    db.SaveChanges();
                }
                if (placeid != null)
                {
                    OrderedPlace op = db.OPlaces.Find(placeid);
                    db.OPlaces.Remove(op);
                    db.SaveChanges();
                }
                if (foodid != null)
                {
                    OrderedFood of = db.OFoods.Find(foodid);
                    db.OFoods.Remove(of);
                    db.SaveChanges();
                }
            }

            
            return RedirectToAction("");
        }




        public ActionResult AddService(int? id)
        {
            if (id == null)
            {

                Response.Redirect("/Home/CreateAnEvent", false);
                return null;

            } 
            using(db = new EMDbContext())
            {
                CurrentEvent = db.Events.Find(id);
                if (CurrentEvent == null)
                {
                    Response.Redirect("/Home/CreateAnEvent", false);
                    return null;
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
        public ActionResult AddService(int? placeid,int? foodid,int? decid,int? photoid,int? amount)
        {
            if (Security.SessionPersister.Currentevent == null)
            {
                Response.Redirect("/Home/CreateAnEvent", false);
                return null;
            }
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
                int foodAmount = 1;
                if (amount != null)
                {
                    foodAmount = (int)amount;
                }

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
                    Security.SessionPersister.Currentevent.TotalCost += ((int)of.FoodCost*foodAmount);
                    db.Entry(Security.SessionPersister.Currentevent).State = EntityState.Modified;
                    db.OFoods.Add(of);
                    db.SaveChanges();

                    ViewBag.Message = "Food Added to your event";
                }

            }
            if (photoid != null)
            {
                int photoamount = 1;
                if (amount != null)
                {
                    photoamount = (int)amount;
                }

                using (db = new EMDbContext())
                {
                    var photo = db.Photographies.Find(photoid);


                    OrderedPhotography of = new OrderedPhotography()
                    {
                        PhotographyCost = photo.PhotographyCost,
                        PhotographyTitle = photo.PhotographyTitle,
                        PhotographyId = photo.PhotographyId,
                        PhotographyDescription = photo.PhotographyDescription,
                        
                        EventId = Security.SessionPersister.Currentevent.EventId

                    };

                    Security.SessionPersister.Currentevent.OrderedPhotographies.Add(of);
                    Security.SessionPersister.Currentevent.TotalCost += ((int)of.Cost * photoamount);
                    db.Entry(Security.SessionPersister.Currentevent).State = EntityState.Modified;
                    db.OPhotographies.Add(of);
                    db.SaveChanges();

                    ViewBag.Message = "photographers Added to your event";
                }

            }


            if (decid != null)
            {
                using (db = new EMDbContext())
                {
                    var dec = db.Decorations.Find(decid);


                    OrderedDecoration of = new OrderedDecoration()
                    {

                        DecorationCategory = dec.DecorationCategory,
                        DecorationCost = dec.DecorationCost,
                        DecorationTitle = dec.DecorationTitle,
                        DecorationDescription = dec.DecorationDescription,
                        EventId = Security.SessionPersister.Currentevent.EventId


                    };

                    Security.SessionPersister.Currentevent.OrderedDecorations.Add(of);
                    Security.SessionPersister.Currentevent.TotalCost += ((int)of.DecorationCost );
                    db.Entry(Security.SessionPersister.Currentevent).State = EntityState.Modified;
                    db.ODecorations.Add(of);
                    db.SaveChanges();

                    ViewBag.Message = "This Decoration Added to your event";
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