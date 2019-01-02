using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class OnlineKorisnik : Korisnik
    {
        private String sifraProfila;
        private Kartica podaciOKreditnojKartici;

        public OnlineKorisnik(String ime, String prezime, String jmbg, DateTime datumRodjenja, String brojTelefona, String email, String sifra, Kartica podaciKartica)
          : base(ime, prezime, jmbg, datumRodjenja, brojTelefona, email) {
             SifraProfila = sifra;
             PodaciOKreditnojKartici = podaciKartica;
        }

        public Kartica PodaciOKreditnojKartici { get => podaciOKreditnojKartici; set => podaciOKreditnojKartici = value; }
        public string SifraProfila { get => sifraProfila; set => sifraProfila = value; }

        public override string IspisiString()
        {
            return string.Format("Ime: {0}" + Environment.NewLine +
               "Prezime: {1}" + Environment.NewLine +
               "Maticni broj: {2}" + Environment.NewLine +
               "Datum rođenja: {3}", ImeKorisnika, PrezimeKorisnika, JmbgKorisnika, DatumRodjenjaKorisnika);
        }
    }
}
