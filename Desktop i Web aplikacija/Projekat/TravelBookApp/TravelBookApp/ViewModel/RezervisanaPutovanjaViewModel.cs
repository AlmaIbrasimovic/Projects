using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.ViewModel
{
    public class RezervisanaPutovanjaViewModel
    {
        public List<Putovanje> izlistajPutovanjaAgencije(int idAgencije) {
            List<Putovanje> putovanjaAgencije = new List<Putovanje>();
            foreach (Putovanje p in Globalna.nasaAgencija.Putovanja) if (p.IdAgencije == idAgencije) putovanjaAgencije.Add(p);
            return putovanjaAgencije;
        }

        public List<Putovanje> izlistajPutovanjaKorisnika() {
            List<Putovanje> putovanjaKorisnika = new List<Putovanje>();
            return putovanjaKorisnika;
        }

        public List<Korisnik> izlistajKorisnikeNaPutovanju() {
            List<Korisnik> korisniciNaPutovanju = new List<Korisnik>();
            return korisniciNaPutovanju;
        }
    }
}
