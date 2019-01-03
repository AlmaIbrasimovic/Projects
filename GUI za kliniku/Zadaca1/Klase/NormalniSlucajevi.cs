using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    sealed class NormalniSlucajevi : Pacijent
    {

        private int brojPosjeta = 1;
        public NormalniSlucajevi(string ime, string prezime, DateTime rodjenje, string jmbg, string Spol, DateTime prijem, string bracno, 
            string lokacija = "",Image slicica = null, int brPo = 0) : 
            base(ime, prezime, rodjenje, jmbg, Spol, prijem, bracno, lokacija,slicica) { }

        public int BrojPosjeta { get => brojPosjeta; set => brojPosjeta = value; }

        public override string ispisiString()
        {
            string rez = "I";
            rez += "me pacijenta: " + _Ime + "\nPrezime pacijenta: " + _Prezime + "\nDatum rodjenja pacijenta: " + _datumRodjenja.Day + "." + _datumRodjenja.Month + "." + _datumRodjenja.Year + "."+ "\nJMBG pacijenta: " + _JMBG + "\nSpol pacijenta: " + _Spol +
                   "\nDatum prijema pacijenta: " + Prijem + "\nBracno stanje pacijenta: " + Brak +"\n";
            return rez;
        }
    }
}
