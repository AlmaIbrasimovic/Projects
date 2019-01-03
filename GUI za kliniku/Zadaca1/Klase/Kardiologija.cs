using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Kardiologija : Ordinacije
    {
        public Kardiologija()
        {
            Aparati.Add("EKG");
            Aparati.Add("Defibrilator");
            TipOrdinacije = "Kardiologija";
            TipDoktora = "Kardiolog";
            DostupnaOrdinacija = true;
        }

        public bool dostupna()
        {
            return DostupnaOrdinacija;
        }
        public string ispisiKardiologiju()
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
