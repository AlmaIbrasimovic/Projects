using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.ViewModel
{
    public class TravelBookViewModel
    {
        public List<Putovanje> prikaziSvaPutovanja() {
            List<Putovanje> svaPutovanja = Globalna.nasaAgencija.Putovanja;
            return svaPutovanja;
        }

        public List<Korisnik> prikaziSveKorisnike() {
            List<Korisnik> sviKorisnici = Globalna.nasaAgencija.Korisnici;
            return sviKorisnici;
        }

        public List<Agencija> prikaziSveAgencije() {
            List<Agencija> sveAgencije = Globalna.nasaAgencija.Agencije;
            return sveAgencije;
        }
    }
}
