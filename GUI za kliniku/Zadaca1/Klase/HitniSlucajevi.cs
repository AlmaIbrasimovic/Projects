using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;

namespace Zadaca1
{
    public class HitniSlucajevi : Pacijent
    {
        private int brojPosjeta = 1;
        public HitniSlucajevi (string ime, string prezime, DateTime rodjenje, string jmbg, string Spol, DateTime prijem, string bracno, string lokacija ="",Image slicica = null,bool hitan = false,int brPos=0) : 
            base(ime, prezime, rodjenje, jmbg, Spol, prijem, bracno, lokacija,slicica) {}
        public int BrojPosjeta { get => brojPosjeta; set => brojPosjeta = value; }

        public override string ispisiString()
        {
            string rez = "\nI";
            rez += "me pacijenta: " + _Ime + "\nPrezime pacijenta: " + _Prezime + "\nDatum rodjenja pacijenta: " +
                   _datumRodjenja.Day + "." + _datumRodjenja.Month + "." + _datumRodjenja.Year + "."  + "\nJMBG pacijenta: " + _JMBG + "\nSpol pacijenta: " + _Spol +
                   "\nDatum prijema pacijenta: " + Prijem + "\nBracno stanje pacijenta: " + Brak + "\n";
            return rez;
        }
    }
}
