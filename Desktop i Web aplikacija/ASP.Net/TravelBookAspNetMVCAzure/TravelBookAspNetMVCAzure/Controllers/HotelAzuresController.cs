using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
    public class HotelAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: HotelAzures
        public ActionResult Index()
        {
            return View(db.HotelAzures.ToList());
        }

        // GET: HotelAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelAzure hotelAzure = db.HotelAzures.Find(id);
            if (hotelAzure == null)
            {
                return HttpNotFound();
            }
            return View(hotelAzure);
        }

        // GET: HotelAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,ime,slika,maxKapacitet,kapacitet,idDestinacije,cijena")] HotelAzure hotelAzure)
        {
            if (ModelState.IsValid)
            {
                db.HotelAzures.Add(hotelAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hotelAzure);
        }

        // GET: HotelAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelAzure hotelAzure = db.HotelAzures.Find(id);
            if (hotelAzure == null)
            {
                return HttpNotFound();
            }
            return View(hotelAzure);
        }

        // POST: HotelAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,ime,slika,maxKapacitet,kapacitet,idDestinacije,cijena")] HotelAzure hotelAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hotelAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hotelAzure);
        }

        // GET: HotelAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HotelAzure hotelAzure = db.HotelAzures.Find(id);
            if (hotelAzure == null)
            {
                return HttpNotFound();
            }
            return View(hotelAzure);
        }

        // POST: HotelAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            HotelAzure hotelAzure = db.HotelAzures.Find(id);
            db.HotelAzures.Remove(hotelAzure);
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
