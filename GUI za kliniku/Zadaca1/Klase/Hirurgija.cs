using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Hirurgija : Ordinacije
    {
        public Hirurgija()
        {
            Aparati.Add("Aparat za anesteziju");
            Aparati.Add("Defibrilator");
            TipOrdinacije = "Hirurgija";
            TipDoktora = "Hirurg";
            DostupnaOrdinacija = true;
        }
        public string ispisiHirurgiju()
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
    }
}
