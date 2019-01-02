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
    public class KarticaAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: KarticaAzures
        public ActionResult Index()
        {
            return View(db.KarticaAzures.ToList());
        }

        // GET: KarticaAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KarticaAzure karticaAzure = db.KarticaAzures.Find(id);
            if (karticaAzure == null)
            {
                return HttpNotFound();
            }
            return View(karticaAzure);
        }

        // GET: KarticaAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KarticaAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,vrstaKartice,datumIsteka,broj,csc")] KarticaAzure karticaAzure)
        {
            if (ModelState.IsValid)
            {
                db.KarticaAzures.Add(karticaAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(karticaAzure);
        }

        // GET: KarticaAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KarticaAzure karticaAzure = db.KarticaAzures.Find(id);
            if (karticaAzure == null)
            {
                return HttpNotFound();
            }
            return View(karticaAzure);
        }

        // POST: KarticaAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,vrstaKartice,datumIsteka,broj,csc")] KarticaAzure karticaAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(karticaAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(karticaAzure);
        }

        // GET: KarticaAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KarticaAzure karticaAzure = db.KarticaAzures.Find(id);
            if (karticaAzure == null)
            {
                return HttpNotFound();
            }
            return View(karticaAzure);
        }

        // POST: KarticaAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KarticaAzure karticaAzure = db.KarticaAzures.Find(id);
            db.KarticaAzures.Remove(karticaAzure);
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
