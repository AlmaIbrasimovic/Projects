using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Zadaca1
{
  //  [Serializable]
    public class HitniSlucajevi : Pacijent
    {
        private int brojPosjeta = 1;
        public HitniSlucajevi (string ime, string prezime, DateTime rodjenje, string jmbg, string Spol, DateTime prijem, string bracno, string lokacija ="",ImageSource slicica = null) : 
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
