using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Stomatologija : Ordinacije
    {
        public Stomatologija()
        {
            Aparati.Add("Aparat za brusenje");
            Aparati.Add("Anestezija");
            TipOrdinacije = "Stomatologija";
            TipDoktora = "Stomatolog";
            DostupnaOrdinacija = true;
        }
        public string ispisiStomatologiju()
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
