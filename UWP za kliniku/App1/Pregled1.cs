using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
    // [Serializable]
    public partial class Pregled
    {
        public int cijenePregleda(Pregled noviPregled)
        {
            if (noviPregled._tipPregleda == "Ortopedski") return 250;
            if (noviPregled._tipPregleda == "Kardioloski") return 500;
            if (noviPregled._tipPregleda == "Dermatoloski") return 50;
            if (noviPregled._tipPregleda == "Internisticki") return 80;
            if (noviPregled._tipPregleda == "Otorinolaringoloski") return 150;
            if (noviPregled._tipPregleda == "Oftamoloski") return 50;
            if (noviPregled._tipPregleda == "Labaratorijski") return 200;
            return 90;
        }
        public string vratiTipPregleda(Pregled noviPregled)
        {
            if (noviPregled._tipPregleda == "Ortopedski") return _tipPregleda;
            if (noviPregled._tipPregleda == "Kardioloski") return _tipPregleda;
            if (noviPregled._tipPregleda == "Dermatoloski") return _tipPregleda;
            if (noviPregled._tipPregleda == "Internisticki") return _tipPregleda;
            if (noviPregled._tipPregleda == "Otorinolaringoloski") return _tipPregleda;
            if (noviPregled._tipPregleda == "Oftamoloski") return _tipPregleda;
            if (noviPregled._tipPregleda == "Labaratorijski") return _tipPregleda;
            return _tipPregleda;
        }
        public string ispisiString()
        {
            if (_tipPregleda == "Vozacki")
            {
                
                string rez = "Datum pregleda: " + _datumPregleda + "\nTip pregleda: " + _tipPregleda + "\nIdete u sljedece ordinacije:\nOftamologija\nOrtopedija i zadnji ste u redu za obje ordinacije.";
                return rez;
            }
            else
            {
                string rez = "Datum pregleda: " + _datumPregleda + "\nTip pregleda: " + _tipPregleda +
                             "\nKoji ste u redu cekanja: " + cekanje(this) + "\nDoktor koji vrsi pregled: " + imeDoktora(_tipPregleda) +"\n";
                return rez;
            }
           
        }
    }
}
