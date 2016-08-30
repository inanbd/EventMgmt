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
    [CustomAuthorize(Roles = "admin")]
    public class DecorationsController : Controller
    {
        private EMDbContext db = new EMDbContext();

        // GET: Decorations
        public ActionResult Index()
        {
            return View(db.Decorations.ToList());
        }

        // GET: Decorations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoration decoration = db.Decorations.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        // GET: Decorations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Decorations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DecorationId,DecorationTitle,DecorationCategory,DecorationDescription,DecorationCost,pic1,pic2,pic3,pic4,pic5")] Decoration decoration)
        {
            if (ModelState.IsValid)
            {
                db.Decorations.Add(decoration);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(decoration);
        }

        // GET: Decorations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoration decoration = db.Decorations.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        // POST: Decorations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DecorationId,DecorationTitle,DecorationCategory,DecorationDescription,DecorationCost,pic1,pic2,pic3,pic4,pic5")] Decoration decoration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(decoration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(decoration);
        }

        // GET: Decorations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Decoration decoration = db.Decorations.Find(id);
            if (decoration == null)
            {
                return HttpNotFound();
            }
            return View(decoration);
        }

        // POST: Decorations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Decoration decoration = db.Decorations.Find(id);
            db.Decorations.Remove(decoration);
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
