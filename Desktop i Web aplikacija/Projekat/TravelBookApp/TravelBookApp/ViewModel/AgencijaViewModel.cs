using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;

namespace TravelBookApp.ViewModel
{
    public class AgencijaViewModel
    {
        public AgencijaViewModel() { }
        public Agencija vratiAgenciju()
        {
            foreach (Agencija nova in Globalna.nasaAgencija.Agencije) {

                if (nova.Id.Equals(Globalna.prijavljenaAgencijaId)) return nova;
            }
            return null;
        }
    }
}
