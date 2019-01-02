using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
    public class KorisnikAzuresController : Controller
    {
        private TravelContext db = new TravelContext();

        // GET: KorisnikAzures
      /*  public ActionResult Index()
        {
            return View(db.KorisnikAzures.ToList());
        }*/

        // GET: KorisnikAzures/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisnikAzure korisnikAzure = db.KorisnikAzures.Find(id);
            if (korisnikAzure == null)
            {
                return HttpNotFound();
            }
            return View(korisnikAzure);
        }

        [AllowAnonymous]
        public ActionResult Contact()
        {
            return RedirectToAction("Contact", "Home");
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }


        // GET: KorisnikAzures/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KorisnikAzures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ime,prezime,jmbg,datumRodjenja,telefon,email,sifra,idKartice")] KorisnikAzure korisnikAzure)
        {//id,createdAt,updatedAt,version,deleted,
            var zaId = db.KorisnikAzures.ToList();
            String id = zaId.Count.ToString();
            korisnikAzure.id = id;
           

            if (ModelState.IsValid)
            {
                
                
                db.KorisnikAzures.Add(korisnikAzure);
                db.SaveChanges();
                
                return RedirectToAction("Index","Home");
            }


            return View(korisnikAzure);
        }

      




        // GET: KorisnikAzures/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisnikAzure korisnikAzure = db.KorisnikAzures.Find(id);
            if (korisnikAzure == null)
            {
                return HttpNotFound();
            }
            return View(korisnikAzure);
        }

        // POST: KorisnikAzures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,ime,prezime,jmbg,datumRodjenja,telefon,email,sifra,idKartice")] KorisnikAzure korisnikAzure)
        {
            if (ModelState.IsValid)
            {
                db.Entry(korisnikAzure).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(korisnikAzure);
        }

        // GET: KorisnikAzures/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KorisnikAzure korisnikAzure = db.KorisnikAzures.Find(id);
            if (korisnikAzure == null)
            {
                return HttpNotFound();
            }
            return View(korisnikAzure);
        }

        // POST: KorisnikAzures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            KorisnikAzure korisnikAzure = db.KorisnikAzures.Find(id);
            db.KorisnikAzures.Remove(korisnikAzure);
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
