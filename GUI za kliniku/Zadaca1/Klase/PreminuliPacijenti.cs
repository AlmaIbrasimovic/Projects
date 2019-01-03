using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class PreminuliPacijenti : IPrint
    {
        private string ime, prezime;
        private DateTime datumSmrti, datumRodjenja;
        private string uzrokSmrti;
        private string spol;
        private bool obdukcija;
        private DateTime datumObdukcije;

        public PreminuliPacijenti(string ime, string prezime, DateTime datumSmrti, DateTime datumRodjenja, string uzrokSmrti, string spol, bool obdukcija = false, DateTime datumObdukcije = default(DateTime))
        {
            Ime = ime;
            Prezime = prezime;
            DatumSmrti = datumSmrti;
            DatumRodjenja = datumRodjenja;
            UzrokSmrti = uzrokSmrti;
            Spol = spol;
            Obdukcija = obdukcija;
            DatumObdukcije = datumObdukcije;
        }

        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public DateTime DatumSmrti { get => datumSmrti; set => datumSmrti = value; }
        public DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public string UzrokSmrti { get => uzrokSmrti; set => uzrokSmrti = value; }
        public string Spol { get => spol; set => spol = value; }
        public bool Obdukcija { get => obdukcija; set => obdukcija = value; }
        public DateTime DatumObdukcije { get => datumObdukcije; set => datumObdukcije = value; }

        public string ispisiString()
        {
            string rez = string.Empty;
            rez += "\nIme: " + Ime + "\nPrezime: " + Prezime + "\nSpol: " + Spol + "\nDatum rođenja: " + DatumRodjenja.Day + "." + DatumRodjenja.Month + "." + DatumRodjenja.Year + "."  +
                   "\nDatum smrti: " + DatumSmrti.Day + "." + DatumRodjenja.Month + "." + DatumRodjenja.Year + "."  + "\nUzrok smrti: " + UzrokSmrti + "\nStarost: " + godine() +
                   " godina";
            if (Obdukcija)
            {
                rez += "\nDatum obdukcije: " + DatumObdukcije + "\n";
            }
            return rez;
        }

        public int godine()
        {
            return datumSmrti.Year - datumRodjenja.Year;
        }
    }
}
