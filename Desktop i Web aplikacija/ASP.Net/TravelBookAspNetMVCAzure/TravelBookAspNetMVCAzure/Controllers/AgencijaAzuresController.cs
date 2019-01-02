using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
    public class AgencijaAzuresController : Controller
    {
        private TravelContext db = new TravelContext();
         

        // GET: AgencijaAzures
        string apiUrl = "http://travelbookrestapi20180602024728.azurewebsites.net/";
          public async Task<ActionResult> Index1()
          {

            List<AgencijaAzure> agencije = new List<AgencijaAzure>();

            using (var client = new HttpClient()) {
                  client.BaseAddress = new Uri(apiUrl);
                  client.DefaultRequestHeaders.Clear();
                  client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                
                  HttpResponseMessage res = await client.GetAsync("api/AgencijaAzures/");
                  if (res.IsSuccessStatusCode) {
                      var response = res.Content.ReadAsStringAsync().Result;
                      agencije = JsonConvert.DeserializeObject<List<AgencijaAzure>>(response);
                   
                }
              }
           

            return View(agencije);           
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

        // GET: AgencijaAzures/Details/5
        public ActionResult Details(string id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
              if (agencijaAzure == null)
              {
                  return HttpNotFound();
              }
              return View(agencijaAzure);
          }

        public String naziv(string id)
        {
          
            AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
            if (agencijaAzure == null)
            {
                return "ne postoji";
            }
            return agencijaAzure.naziv;
        }

          // GET: AgencijaAzures/Create
          public ActionResult Create()
          {
              return View();
          }

          // POST: AgencijaAzures/Create
          // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Create([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,idKartica,telefon,grad,lokacija,sifra,email")] AgencijaAzure agencijaAzure)
          {
              if (ModelState.IsValid)
              {
                  db.AgencijaAzures.Add(agencijaAzure);
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }

              return View(agencijaAzure);
          }

          // GET: AgencijaAzures/Edit/5
          public ActionResult Edit(string id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
              if (agencijaAzure == null)
              {
                  return HttpNotFound();
              }
              return View(agencijaAzure);
          }

          // POST: AgencijaAzures/Edit/5
          // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
          // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
          [HttpPost]
          [ValidateAntiForgeryToken]
          public ActionResult Edit([Bind(Include = "id,createdAt,updatedAt,version,deleted,naziv,idKartica,telefon,grad,lokacija,sifra,email")] AgencijaAzure agencijaAzure)
          {
              if (ModelState.IsValid)
              {
                  db.Entry(agencijaAzure).State = EntityState.Modified;
                  db.SaveChanges();
                  return RedirectToAction("Index");
              }
              return View(agencijaAzure);
          }

          // GET: AgencijaAzures/Delete/5
          public ActionResult Delete(string id)
          {
              if (id == null)
              {
                  return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
              }
              AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
              if (agencijaAzure == null)
              {
                  return HttpNotFound();
              }
              return View(agencijaAzure);
          }

          // POST: AgencijaAzures/Delete/5
          [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public ActionResult DeleteConfirmed(string id)
          {
              AgencijaAzure agencijaAzure = db.AgencijaAzures.Find(id);
              db.AgencijaAzures.Remove(agencijaAzure);
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
