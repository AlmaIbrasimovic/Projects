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
    public class PrevozAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: PrevozAzures
        public ActionResult Index()
        {
            return View(db.PrevozAzures.ToList());
        }

        // GET: PrevozAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevozAzure prevozAzure = db.PrevozAzures.Find(id);
            if (prevozAzure == null)
            {
                return HttpNotFound();
            }
            return View(prevozAzure);
        }

        // GET: PrevozAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PrevozAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,ime,vrstaPrevoza,maxKapacitet,kapacitet,cijena,idDestinacije")] PrevozAzure prevozAzure)
        {
            if (ModelState.IsValid)
            {
                db.PrevozAzures.Add(prevozAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prevozAzure);
        }

        // GET: PrevozAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevozAzure prevozAzure = db.PrevozAzures.Find(id);
            if (prevozAzure == null)
            {
                return HttpNotFound();
            }
            return View(prevozAzure);
        }

        // POST: PrevozAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,ime,vrstaPrevoza,maxKapacitet,kapacitet,cijena,idDestinacije")] PrevozAzure prevozAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prevozAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prevozAzure);
        }

        // GET: PrevozAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrevozAzure prevozAzure = db.PrevozAzures.Find(id);
            if (prevozAzure == null)
            {
                return HttpNotFound();
            }
            return View(prevozAzure);
        }

        // POST: PrevozAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PrevozAzure prevozAzure = db.PrevozAzures.Find(id);
            db.PrevozAzures.Remove(prevozAzure);
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
