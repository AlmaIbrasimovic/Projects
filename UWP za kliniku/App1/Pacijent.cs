using System;
using System.Collections.Generic;

using System.Linq;

using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

namespace Zadaca1
{
  
    public abstract class Pacijent : IPrint
    {
        private string Ime177270, Prezime17270;
        private DateTime datumRodjenja17270;
        private string JMBG17270;
        private string spol17270; 
        private DateTime datumPrijema17270;
        private string bracnoStanje17270;
        private int brojPosjeta17270 = 1;
        private bool preminuo;
        private ImageSource slika;
        public Pacijent(string ime, string prezime, DateTime rodjenje, string jmbg, string Spol, DateTime prijem, string bracno, string lokacija = "", ImageSource slicica = null, int brojPosjeta = 0, bool hitan = false,bool preminuo = false)
        {
            _Ime = ime;
            _Prezime = prezime;
            _datumRodjenja = rodjenje;
            _JMBG = jmbg;
            _Spol = Spol;
            Prijem = prijem;
            Brak = bracno;
            Preminuo = preminuo;
            Slika = slicica;
          
        }
        public int BrojPosjeta
        {
            get { return brojPosjeta17270; }
            set { brojPosjeta17270 = value; }
        }
        public string _Ime
        {
            get { return Ime177270; }
            set { Ime177270 = value; }
        }

        public string _Prezime
        {
            get { return Prezime17270; }
            set { Prezime17270 = value; }
        }

        public DateTime _datumRodjenja
        {
            get { return datumRodjenja17270; }
            set { datumRodjenja17270 = value; }
        }

        public string _JMBG
        {
            get { return JMBG17270; }
            set
            {  
                if (!validirajJMBG(value)) throw new Exception("JMBG nije OK!");
                JMBG17270 = value;
            }
        }

        private bool ValidacijaDatumaRodjenaZaJmbg(string jmbg)
        {
            string dan = _datumRodjenja.Day.ToString();
            int tempDan = Convert.ToInt32(dan);
            if (tempDan <= 9) dan = "0" + dan;
            string mjesec = _datumRodjenja.Month.ToString();
            int tempMjesec = Convert.ToInt32(mjesec);
            if (tempMjesec <= 9) mjesec = "0" + mjesec;
            string godina = _datumRodjenja.Year.ToString();
            godina = godina.Substring(1, 3);
            string skraceni = jmbg.Substring(0, 7);
            string formiraniDatum = dan + mjesec + godina;
            bool jesteOK = true;
            for (int i = 0; i < formiraniDatum.Length; i++)
            {
                if (formiraniDatum[i] != skraceni[i])
                {
                    jesteOK = false;
                    break;
                }
            }
            return jesteOK;
        }
        bool validirajJMBG(string jmbg)
        {
            if(!globalnaKlasa.validacijaJMBG(jmbg)) throw new Exception("JMBG mora biti dužine 13!");
            string spol = _Spol; // od 000-499 muško, 500-999 žensko
            string kodSpola = String.Empty;
            kodSpola = jmbg.Substring(9, 3);
            int tempKodSpola = Convert.ToInt32(kodSpola);
            bool jelOK = true;
            bool datum = ValidacijaDatumaRodjenaZaJmbg(jmbg);
            if (!datum) return false;
            if (jmbg.Length != 13) return false;
            if (ValidacijaDatumaRodjenaZaJmbg(jmbg))
            {
                if (spol == "Žensko")
                {
                    if (tempKodSpola < 500 || tempKodSpola <= 0)
                        jelOK = false;
                }
                else if (spol == "Muško" && tempKodSpola > 499) jelOK = false;
            }
           
            return jelOK;
        }
        public string _Spol
        {
            get { return spol17270; }
            set { spol17270 = value; }
        }

        public DateTime Prijem
        {
            get { return datumPrijema17270; }
            set { datumPrijema17270 = value; }
        }

        public string Brak
        {
            get { return bracnoStanje17270; }
            set { bracnoStanje17270 = value; }
        }

        public bool Preminuo { get => preminuo; set => preminuo = value; }
        public ImageSource Slika { get => slika; set => slika = value; }

        abstract public string ispisiString();
    }
}
