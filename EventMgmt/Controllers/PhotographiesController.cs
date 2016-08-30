using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DAL;
using EventMgmt.Security;

namespace EventMgmt.Controllers
{

    [CustomAuthorize(Roles ="admin")]
    
    public class PhotographiesController : Controller
    {
        private EMDbContext db = new EMDbContext();

        // GET: Photographies
        public ActionResult Index()
        {
            return View(db.Photographies.ToList());
        }

        // GET: Photographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photography photography = db.Photographies.Find(id);
            if (photography == null)
            {
                return HttpNotFound();
            }
            return View(photography);
        }

        // GET: Photographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photographies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PhotographyId,PhotographyTitle,PhotographyDescription,PhotographyCost,pic1,pic2,pic3,pic4,pic5")] Photography photography)
        {
            if (ModelState.IsValid)
            {
                db.Photographies.Add(photography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(photography);
        }

        // GET: Photographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photography photography = db.Photographies.Find(id);
            if (photography == null)
            {
                return HttpNotFound();
            }
            return View(photography);
        }

        // POST: Photographies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PhotographyId,PhotographyTitle,PhotographyDescription,PhotographyCost,pic1,pic2,pic3,pic4,pic5")] Photography photography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(photography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(photography);
        }

        // GET: Photographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Photography photography = db.Photographies.Find(id);
            if (photography == null)
            {
                return HttpNotFound();
            }
            return View(photography);
        }

        // POST: Photographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Photography photography = db.Photographies.Find(id);
            db.Photographies.Remove(photography);
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
