using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Zadaca1
{
  
    public class Karton : IPrint
    {
        private  string imePacijenta17270;
       
        private string jmbg17270;
        private DateTime datumZadnjegPregleda17270;
        private List<string> listaBolesti17270 = new List<string>();
        private List<string> listaAlergija17270 = new List<string>();
        private List<string> misljenjaDoktora17270 = new List<string>();
        private List<string> listaTerapija17270 = new List<string>();
        public Karton (string ime, string JMBG, DateTime zadnjiPregled, List<string> bolesti, List<string> alergije,List<string> misljenja, List<string> terapije)
        {
            ImePacijenta = ime;
            Jmbg = JMBG;
            DatumZadnjegPregleda = zadnjiPregled;
            ListaBolesti = bolesti;
            ListaAlergija = alergije;
            MisljenjaDoktora = misljenja;
            ListaTerapija = terapije;
        }
        public Karton(List<string> teraapije)
        {
            ListaTerapija = teraapije;
        }
        public string ImePacijenta { get => imePacijenta17270; set => imePacijenta17270 = value; }
      
        public string Jmbg { get => jmbg17270; set => jmbg17270 = value; }
        public DateTime DatumZadnjegPregleda { get => datumZadnjegPregleda17270; set => datumZadnjegPregleda17270 = value; }
        public List<string> ListaBolesti { get => listaBolesti17270; set => listaBolesti17270 = value; }
        public List<string> ListaAlergija { get => listaAlergija17270; set => listaAlergija17270 = value; }
        public List<string> MisljenjaDoktora { get => misljenjaDoktora17270; set => misljenjaDoktora17270 = value; }
        public List<string> ListaTerapija { get => listaTerapija17270; set => listaTerapija17270 = value; }

        public string ispisiString()
        {
            string rezultat = "I";
            rezultat += "me i prezime pacijenta: " + ImePacijenta  +
                        "\nDatum zadnjeg pregleda pacijenta: " + DatumZadnjegPregleda + "\nJMBG pacijenta: " + Jmbg +
                        "\nSpol pacijenta: " ;
            rezultat += "\n\nLista bolesti:\n";
            for (int i = 0; i < ListaBolesti.Count; i++)
            {
                rezultat += ListaBolesti[i] +"\n";
            }
            rezultat += "\nLista alergija pacijenta:\n";
            for (int i = 0; i < ListaAlergija.Count; i++)
            {
                rezultat += ListaAlergija[i] + "\n";
            }
            rezultat += "\nLista terapija koje je primao pacijent:\n";
            for (int i = 0; i < ListaTerapija.Count; i++)
            {
                rezultat += ListaTerapija[i] + "\n";
            }
            rezultat += "\nMisljenja doktora o dosadasnjim bolestima:\n";
            for (int i = 0; i < MisljenjaDoktora.Count; i++)
            {
                rezultat += MisljenjaDoktora[i] + "\n";
            }
            rezultat += "\n";
            return rezultat;
        }
    }  
}
