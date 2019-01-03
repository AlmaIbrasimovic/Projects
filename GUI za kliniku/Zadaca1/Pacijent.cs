using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public abstract class Pacijent : IPrint
    {
        private string Ime177270, Prezime17270;
        private DateTime datumRodjenja17270;
        private Int64 JMBG17270;
        private string spol17270; 
        private DateTime datumPrijema17270;
        private string bracnoStanje17270;
        private int brojPosjeta17270 = 1;
        private bool preminuo;
        public Pacijent(string ime, string prezime, DateTime rodjenje, Int64 jmbg, string Spol, DateTime prijem, string bracno, int brojPosjeta = 0, bool preminuo = false)
        {
            _Ime = ime;
            _Prezime = prezime;
            _datumRodjenja = rodjenje;
            _JMBG = jmbg;
            _Spol = Spol;
            Prijem = prijem;
            Brak = bracno;
            Preminuo = preminuo;
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

        public Int64 _JMBG
        {
            get { return JMBG17270; }
            set { JMBG17270 = value; }
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

        abstract public string ispisiString();
    }
}
