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
    public class RezervisanaPutovanjaAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: RezervisanaPutovanjaAzures
        public ActionResult Index()
        {
            return View(db.RezervisanaPutovanjaAzures.ToList());
        }

        // GET: RezervisanaPutovanjaAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure = db.RezervisanaPutovanjaAzures.Find(id);
            if (rezervisanaPutovanjaAzure == null)
            {
                return HttpNotFound();
            }
            return View(rezervisanaPutovanjaAzure);
        }

        // GET: RezervisanaPutovanjaAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RezervisanaPutovanjaAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,idKorisnika,idPutovanja")] RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure)
        { 
            if (ModelState.IsValid)
            { 
                db.RezervisanaPutovanjaAzures.Add(rezervisanaPutovanjaAzure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(rezervisanaPutovanjaAzure);
        }

        // GET: RezervisanaPutovanjaAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure = db.RezervisanaPutovanjaAzures.Find(id);
            if (rezervisanaPutovanjaAzure == null)
            {
                return HttpNotFound();
            }
            return View(rezervisanaPutovanjaAzure);
        }

        // POST: RezervisanaPutovanjaAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,idKorisnika,idPutovanja")] RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rezervisanaPutovanjaAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rezervisanaPutovanjaAzure);
        }

        // GET: RezervisanaPutovanjaAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure = db.RezervisanaPutovanjaAzures.Find(id);
            if (rezervisanaPutovanjaAzure == null)
            {
                return HttpNotFound();
            }
            return View(rezervisanaPutovanjaAzure);
        }

        // POST: RezervisanaPutovanjaAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            RezervisanaPutovanjaAzure rezervisanaPutovanjaAzure = db.RezervisanaPutovanjaAzures.Find(id);
            db.RezervisanaPutovanjaAzures.Remove(rezervisanaPutovanjaAzure);
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
