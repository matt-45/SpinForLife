using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SpinForLife.Models;

namespace SpinForLife.Controllers
{
    public class ReservedBikesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: ReservedBikes
        public ActionResult Index()
        {
            var reservedBikes = db.ReservedBikes.Include(r => r.Event).Include(r => r.Team);
            return View(reservedBikes.ToList());
        }

        // GET: ReservedBikes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBike reservedBike = db.ReservedBikes.Find(id);
            if (reservedBike == null)
            {
                return HttpNotFound();
            }
            return View(reservedBike);
        }

        // GET: ReservedBikes/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.Events, "Id", "Id");
            ViewBag.Id = new SelectList(db.Teams, "Id", "Name");
            return View();
        }

        // POST: ReservedBikes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IsActive,Row,Column,EventId")] ReservedBike reservedBike)
        {
            if (ModelState.IsValid)
            {
                db.ReservedBikes.Add(reservedBike);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.Events, "Id", "Id", reservedBike.EventId);
            ViewBag.Id = new SelectList(db.Teams, "Id", "Name", reservedBike.Id);
            return View(reservedBike);
        }

        // GET: ReservedBikes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBike reservedBike = db.ReservedBikes.Find(id);
            if (reservedBike == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Id", reservedBike.EventId);
            ViewBag.Id = new SelectList(db.Teams, "Id", "Name", reservedBike.Id);
            return View(reservedBike);
        }

        // POST: ReservedBikes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IsActive,Row,Column,EventId")] ReservedBike reservedBike)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reservedBike).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.Events, "Id", "Id", reservedBike.EventId);
            ViewBag.Id = new SelectList(db.Teams, "Id", "Name", reservedBike.Id);
            return View(reservedBike);
        }

        // GET: ReservedBikes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReservedBike reservedBike = db.ReservedBikes.Find(id);
            if (reservedBike == null)
            {
                return HttpNotFound();
            }
            return View(reservedBike);
        }

        // POST: ReservedBikes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReservedBike reservedBike = db.ReservedBikes.Find(id);
            db.ReservedBikes.Remove(reservedBike);
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
