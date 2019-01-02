using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBookApp.Model
{
   public abstract class Korisnik : IPrint
    {
        private int id;
        private String imeKorisnika;
        private String prezimeKorisnika;
        private String jmbgKorisnika;
        private DateTime datumRodjenjaKorisnika;
        private String kontaktTelefon;
        private String emailAdresa;

        public Korisnik(String ime, String prezime, String jmbg, DateTime datumRodjenja, String brojTelefona, String email)
        {
            id = Globalna.idSvihKorisnika++;
            ImeKorisnika = ime;
            PrezimeKorisnika = prezime;
            JmbgKorisnika = jmbg;
            DatumRodjenjaKorisnika = datumRodjenja;
            KontaktTelefon = brojTelefona;
            EmailAdresa = email;
        }
        public int Id { get => id; }
        public string ImeKorisnika { get => imeKorisnika; set => imeKorisnika = value; }
        public string PrezimeKorisnika { get => prezimeKorisnika; set => prezimeKorisnika = value; }
        public string JmbgKorisnika { get => jmbgKorisnika; set => jmbgKorisnika = value; }
        public DateTime DatumRodjenjaKorisnika { get => datumRodjenjaKorisnika; set => datumRodjenjaKorisnika = value; }
        public string KontaktTelefon { get => kontaktTelefon; set => kontaktTelefon = value; }
        public string EmailAdresa { get => emailAdresa; set => emailAdresa = value; }
     
        public virtual string IspisiString()
        {
            return string.Format("Ime: {0}" + Environment.NewLine +
                                 "Prezime: {1}" + Environment.NewLine +
                                 "Maticni broj: {2}" + Environment.NewLine +
                                 "Datum rođenja: {3}", ImeKorisnika, PrezimeKorisnika, JmbgKorisnika, DatumRodjenjaKorisnika);
        }
    
    }
}
