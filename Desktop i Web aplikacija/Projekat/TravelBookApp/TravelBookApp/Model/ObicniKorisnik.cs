using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
    public class ObicniKorisnik : Korisnik
    {
        public ObicniKorisnik(String ime, String prezime, String jmbg, DateTime datumRodjenja, String brojTelefona, String email)
          : base(ime, prezime, jmbg, datumRodjenja, brojTelefona, email) { }

        public override string IspisiString()
        {
            return string.Format("Ime: {0}" + Environment.NewLine +
               "Prezime: {1}" + Environment.NewLine +
               "Maticni broj: {2}" + Environment.NewLine +
               "Datum rođenja: {3}", ImeKorisnika, PrezimeKorisnika, JmbgKorisnika, DatumRodjenjaKorisnika);
        }
    }
}
