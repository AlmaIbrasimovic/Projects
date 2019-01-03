using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Laboratorija : Ordinacije
    {
        public Laboratorija()
        {
            Aparati.Add("Aparat za testiranje krvi");
            Aparati.Add("Ono sto vrti krv");
            Aparati.Add("Sterilizator");
            TipOrdinacije = "Laboratorija";
            TipDoktora = "Laborant";
            DostupnaOrdinacija = true;
        }

        public bool dostupna()
        {
            return DostupnaOrdinacija;
        }
        public string ispisiLaboratoriju()
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
