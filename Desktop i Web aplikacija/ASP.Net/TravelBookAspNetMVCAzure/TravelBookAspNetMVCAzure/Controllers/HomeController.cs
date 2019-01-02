using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TravelBookAspNetMVCAzure.Models;

namespace TravelBookAspNetMVCAzure.Controllers
{
     
    public class HomeController : Controller
    {
        private TravelContext db = new TravelContext();
        static String error = "ok";
        public ActionResult Index()
        {
            
            if(error != "ok") ModelState.AddModelError("pokazi", error);
            error = "ok";
            
            var model = db.PutovanjeAzures.ToList();
            return View(model);
        }

        public ActionResult PosaljiEmail(String destinacija,String ime,String idPutovanja)
        {
          
            var query = from a in db.KorisnikAzures
                        where a.ime.Equals(ime)
                        select a;
            var rez = query.FirstOrDefault();
            String rezultat = rezervacija(idPutovanja, rez.id);
            error = rezultat;
            if(rezultat == "ok") posalji(destinacija,rez.email); //validan email
            return RedirectToAction("Index");

        }

        public String rezervacija(String putovanje, String idKorisnika)
        {
            var query1 = from a in db.PutovanjeAzures
                        where a.id.Equals(putovanje)
                        select a;
            var rez1 = query1.FirstOrDefault();
            if (rez1.minBrojPutnika >= rez1.maxBrojPutnika - 1)
            {                
                return "Sva mjesta su popunjena!";
            }           
            var samoZaID = db.RezervisanaPutovanjaAzures.ToList();
            String id = samoZaID.Count.ToString();

            var query = from a in db.RezervisanaPutovanjaAzures
                        where a.idKorisnika.Equals(idKorisnika)
                        select a;

            List<RezervisanaPutovanjaAzure>  rez = query.ToList();
            List<PutovanjeAzure> putovanja = new List<PutovanjeAzure>();
            foreach(RezervisanaPutovanjaAzure re in rez)
            {
                var q = from k in db.PutovanjeAzures
                        where k.id.Equals(re.idPutovanja)
                        select k;
                putovanja.AddRange(q.ToList());
            }

          
            foreach (PutovanjeAzure p in putovanja)
            {
                if (rez1.datumPolaska <= p.datumPolaska && rez1.datumPovratka <= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                else if (rez1.datumPolaska >= p.datumPolaska && rez1.datumPolaska <= p.datumPovratka && rez1.datumPovratka >= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                else if(rez1.datumPolaska <= p.datumPolaska && rez1.datumPovratka >= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                else if(rez1.datumPolaska >= p.datumPolaska && rez1.datumPovratka <= p.datumPovratka) return "Imate već rezervisano putovanje u tom terminu!";
                
            }
            
            RezervisanaPutovanjaAzure r = new RezervisanaPutovanjaAzure();
            r.idPutovanja = rez1.id;
            r.idKorisnika = idKorisnika; 
            r.id = id; 
            r.deleted = false;
            r.createdAt = DateTimeOffset.Now;
            r.updatedAt = DateTimeOffset.Now;
            rez1.minBrojPutnika = rez1.minBrojPutnika + 1;
            db.RezervisanaPutovanjaAzures.Add(r);
            db.SaveChanges();
            return "ok";

        }

        public ActionResult About()
        {
            ViewBag.Message = "O agenciji";

            return View();
        }    


        public ActionResult Contact()
        {
            //iskoristen api
           return RedirectToAction("Index1", "AgencijaAzures");       

        }

        public string funkcija (string id)
        {
            var kontroler = new DestinacijaAzuresController();
            return kontroler.vratiIme(id);
        }

        public void posalji(String destinacija,String email)
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("zlatakaric@hotmail.com"); //treba email stavit
            mail.From = new MailAddress("travelbookTB@gmail.com");
            mail.Subject = "TravelBook";
            string Body = "Uspješno ste rezervisali Vaše putovanje za "+destinacija;
            mail.Body = Body;
            
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com"; 
            smtp.Credentials = new System.Net.NetworkCredential("travelbookTB@gmail.com", "sifra123");            
            smtp.EnableSsl = true;
            smtp.Send(mail);        
         
        }
    }
}