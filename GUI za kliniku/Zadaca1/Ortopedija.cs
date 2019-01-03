using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public class Ortopedija : Ordinacije
    {
        public Ortopedija()
        {
            /*Aparati.Add("Laseri");
            Aparati.Add("Vapozoni");
            Aparati.Add("Masazeri");*/
            TipOrdinacije = "Ortopedija";
            TipDoktora = "Ortoped";
            DostupnaOrdinacija = true;
        }
        public string ispisiOrtopediju()
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
