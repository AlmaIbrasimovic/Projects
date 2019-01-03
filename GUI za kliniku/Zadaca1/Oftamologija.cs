using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Oftamologija : Ordinacije
    {
        public Oftamologija()
        {
            Aparati.Add("Laseri");
            Aparati.Add("Mikroskop");
            Aparati.Add("Anomaloskopi");
            TipOrdinacije = "Oftamologija";
            TipDoktora = "Oftamolog";
            DostupnaOrdinacija = true;
        }
        public string ispisiOftamologiju()
        {
            string rezultat = "Vrste aparata: ";
            for (int i = 0; i < Aparati.Count; i++)
            {
                if (i == Aparati.Count - 1) rezultat += Aparati[i];
                else rezultat += Aparati[i] + ", ";
            }
            rezultat += "\nTip ordinacije: " + TipOrdinacije + "\nDoktor:  " + TipDoktora;
            return rezultat;
        }
        public bool dostupna()
        {
            return DostupnaOrdinacija;
        }
    }
}
