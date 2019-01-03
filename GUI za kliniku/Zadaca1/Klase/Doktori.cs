using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Doktori : Uposlenici
    {
        private int brojPregledanihPacijenata = 0;
        private double dodatnoZaSvakogPacijenta = 0.02D;
        private string tipDoktora;
        private string imeDoktora;
        private string prezimeDoktora;
        public Doktori(string ime, string prezime, int zagarantovanaPlata, string tip, string user, string pass,
            int brPregledanih = 0) : base(zagarantovanaPlata, user, pass)
        {
            ImeDoktora = ime;
            PrezimeDoktora = prezime;
            BrojPregledanihPacijenata = brPregledanih;
            doc = tip;
        }

        public int BrojPregledanihPacijenata { get => brojPregledanihPacijenata; set => brojPregledanihPacijenata = value; }
        public double DodatnoZaSvakogPacijenta { get => dodatnoZaSvakogPacijenta; set => dodatnoZaSvakogPacijenta = value; }
        public string doc { get => tipDoktora; set => tipDoktora = value; }
        public string PrezimeDoktora { get => prezimeDoktora; set => prezimeDoktora = value; }
        public string ImeDoktora { get => imeDoktora; set => imeDoktora = value; }

        public Doktori (string tip,int zagarantovanaPlata = 0, int brPregledanih = 0) : base()
        {
            doc = tip;
        }
        public double plataDoktora(string doc)
        {
            double plata = 0;
            if (this.doc == "Ortoped")
            {
                if (globalnaKlasa.ortoDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.ortoDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Kardiolog")
            {
                if (globalnaKlasa.kardDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.kardDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Dermatolog")
            {
                if (globalnaKlasa.dermaDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.dermaDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Internista")
            {
                if (globalnaKlasa.interDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.interDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Otorinolaringolog")
            {
                if (globalnaKlasa.otoroDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.otoroDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Oftamolog")
            {
                if (globalnaKlasa.oftaDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.oftaDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Laborant")
            {
                if (globalnaKlasa.labDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.labDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            else if (this.doc == "Stomatolog")
            {
                if (globalnaKlasa.stomaDoktori < 20)
                    plata += ZagarantovanaPlata +
                             (ZagarantovanaPlata * globalnaKlasa.stomaDoktori * dodatnoZaSvakogPacijenta);
                else plata += ZagarantovanaPlata;
            }
            return plata;
        }
        public override string ispisiString()
        {
            string rez = string.Empty;
            rez += "Ime: " + imeDoktora + "\nPrezime: " + prezimeDoktora + "\nTip doktora: " + tipDoktora + "\n";
            return rez;
        }
    }
}
