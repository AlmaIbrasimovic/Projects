using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace Zadaca1
{
    class Dermatologija : Ordinacije
    {
        public Dermatologija()
        {
            Aparati.Add("Laseri");
            Aparati.Add("Vapozoni");
            Aparati.Add("Masazeri");
            TipOrdinacije = "Dermatologogija";
            TipDoktora = "Dermatolog";
            DostupnaOrdinacija = false;
        }
        public string ispisiDermatologiju()
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
