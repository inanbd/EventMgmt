using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;

namespace EventMgmt.Controllers
{
    public class EventsController : Controller
    {
        private EMDbContext db = new EMDbContext();

        // GET: Events
        public ActionResult Index()
        {
            var events = db.Events.Include(X => X.user);
         
            return View(events.ToList().Where(x => x.user.UserId == Security.SessionPersister.user.UserId));
        }

        // GET: Events/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            List<object> model = new List<object>();
            model.Add(db.OFoods.Where(x => x.EventId == id).ToList());
            model.Add(db.OPlaces.Where(x => x.EventId == id).ToList());
            model.Add(db.ODecorations.Where(x => x.EventId == id).ToList());
            return View(model);
            //return View(@event);
        }

        // GET: Events/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName");
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EventId,UserId,EventTitle,EventDate,IsConfirmed,TotalCost")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.IsConfirmed = false;
                @event.UserId = Security.SessionPersister.user.UserId;
               // @event.user = Security.SessionPersister.user;
                db.Events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", @event.UserId);
            return View(@event);
        }

        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            if (@event.IsConfirmed == false)
            {
                ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", @event.UserId);
                return View(@event);
            }
            else
            {
                return View("IsConfirmed");
            }
            
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EventId,UserId,EventTitle,EventDate,IsConfirmed,TotalCost")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "UserId", "UserName", @event.UserId);
            return View(@event);
        }

        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.Events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.Events.Find(id);
            db.Events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
