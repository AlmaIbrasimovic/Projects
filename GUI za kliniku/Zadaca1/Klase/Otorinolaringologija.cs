using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    class Otorinolaringologija : Ordinacije
    {
        public Otorinolaringologija()
        {
            Aparati.Add("Slusni aparat");
            Aparati.Add("Mikroskop");
            Aparati.Add("Defibrilatori");
            TipOrdinacije = "Otorinolaringologija";
            TipDoktora = "Otorinolaringolog";
            DostupnaOrdinacija = true;
        }
        public string ispisiOtorinolaringologiju()
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
