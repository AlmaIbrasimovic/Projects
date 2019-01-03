using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    public abstract class Ordinacije
    {
        private string tipOrdinacije;
        private List<string> aparati = new List<string>();
        private string tipDoktora;
        private  bool dostupnaOrdinacija;

        public Ordinacije(string tip, List<string> apararat, string doktor, bool dostupna)
        {
            TipDoktora = doktor;
            TipOrdinacije = tip;
            Aparati = apararat;
            DostupnaOrdinacija = dostupna;
        }

        public Ordinacije() {}

        public string TipDoktora { get => tipDoktora; set => tipDoktora = value; }
        public string TipOrdinacije { get => tipOrdinacije; set => tipOrdinacije = value; }
        public List<string> Aparati { get => aparati; set => aparati = value; }
        public bool DostupnaOrdinacija { get => dostupnaOrdinacija; set => dostupnaOrdinacija = value; }

        public bool daLiJeDostupna(int redniBrojOrdinacije)
        {
            switch (redniBrojOrdinacije)
            {
                case 1: Ortopedija orto = new Ortopedija();
                        return orto.dostupna();
                case 2:
                        Kardiologija kard = new Kardiologija();
                        return kard.dostupna();
                case 3:
                        Dermatologija derma = new Dermatologija();
                        return derma.dostupna();
                case 4:
                        Internisticka inter = new Internisticka();
                        return inter.dostupna();
                case 5:
                        Otorinolaringologija otoro = new Otorinolaringologija();
                        return otoro.dostupna();
                case 6:
                        Oftamologija ofto = new Oftamologija();
                        return ofto.dostupna();
                case 7:
                        Laboratorija lab = new Laboratorija();
                        return lab.dostupna();
                case 8:
                        Stomatologija stoma = new Stomatologija();
                        return stoma.dostupna();
            }
            return true;
        }
    }
}
