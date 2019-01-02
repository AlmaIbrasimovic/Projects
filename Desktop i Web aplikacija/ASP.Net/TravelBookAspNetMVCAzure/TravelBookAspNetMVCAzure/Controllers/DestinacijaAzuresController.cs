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
    public class DestinacijaAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: DestinacijaAzures
        public ActionResult Index()
        {
            return View(db.DestinacijaAzures.ToList());
        }

        // GET: DestinacijaAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinacijaAzure destinacijaAzure = db.DestinacijaAzures.Find(id);
            if (destinacijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(destinacijaAzure);
        }
        
        public string vratiIme (string id)
        {
            string ime = string.Empty;
            DestinacijaAzure destinacijaAzure = db.DestinacijaAzures.Find(id);
            if (destinacijaAzure != null)
            {
                ime = destinacijaAzure.naziv;
            }
            return ime;
        }

        public string vratiSliku(string id)
        {
            string slika = string.Empty;
            DestinacijaAzure destinacijaAzure = db.DestinacijaAzures.Find(id);
            if (destinacijaAzure != null)
            {
                slika = destinacijaAzure.slika;
            }
            return slika;
        }

        // GET: DestinacijaAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DestinacijaAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,drzava,kontinent,slika")] DestinacijaAzure destinacijaAzure)
        {
            if (ModelState.IsValid)
            {
                db.DestinacijaAzures.Add(destinacijaAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(destinacijaAzure);
        }

        // GET: DestinacijaAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinacijaAzure destinacijaAzure = db.DestinacijaAzures.Find(id);
            if (destinacijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(destinacijaAzure);
        }

        // POST: DestinacijaAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,drzava,kontinent,slika")] DestinacijaAzure destinacijaAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(destinacijaAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(destinacijaAzure);
        }

        // GET: DestinacijaAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DestinacijaAzure destinacijaAzure = db.DestinacijaAzures.Find(id);
            if (destinacijaAzure == null)
            {
                return HttpNotFound();
            }
            return View(destinacijaAzure);
        }

        // POST: DestinacijaAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DestinacijaAzure destinacijaAzure = db.DestinacijaAzures.Find(id);
            db.DestinacijaAzures.Remove(destinacijaAzure);
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
