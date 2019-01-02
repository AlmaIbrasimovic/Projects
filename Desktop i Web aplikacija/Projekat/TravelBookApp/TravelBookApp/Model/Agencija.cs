using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class Agencija : IPrint
    {
        private int id;
        private String nazivAgencije;
        private Kartica podaciOBankovnomRacunu;
        private String kontaktTelefon;
        private String emailAdresa;
        private String grad;
        private String lokacija;
        private String sifra;

        public Agencija() { }

        public Agencija(String naziv, Kartica kartica, String telefon, String email,String grad, String adresa, String sifra)
        {
            id = Globalna.idSvihAgencija++;
            NazivAgencije = naziv;
            PodaciOBankovnomRacunu = kartica;
            KontaktTelefon = telefon;
            EmailAdresa = email;
            Grad = grad;
            Lokacija = adresa;
            Sifra = sifra;
        }
        public int Id { get => id;  }
        public string NazivAgencije { get => nazivAgencije; set => nazivAgencije = value; }
        public Kartica PodaciOBankovnomRacunu { get => podaciOBankovnomRacunu; set => podaciOBankovnomRacunu = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string EmailAdresa { get => emailAdresa; set => emailAdresa = value; }
        public string Lokacija { get => lokacija; set => lokacija = value; }
        public string Grad { get => grad; set => grad = value; }
        public string Sifra { get => sifra; set => sifra = value; }

        public string IspisiString()
        {
            return string.Format("Naziv: {0}" + Environment.NewLine +
                                 "E-mail: {1}" + Environment.NewLine +
                                 "Kontakt telefon: {2}" + Environment.NewLine +
                                 "Adresa: {3}", NazivAgencije, EmailAdresa, KontaktTelefon, Lokacija);
        }
    }
}
