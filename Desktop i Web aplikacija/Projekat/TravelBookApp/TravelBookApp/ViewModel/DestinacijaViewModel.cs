using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.ViewModel
{
    public class DestinacijaViewModel
    {
        public void dodajDestinaciju(string naziv, String drzava, Kontinent kontinent, Image slikeDestinacije) {
          Destinacija destinacija =  new Destinacija(naziv,drzava,kontinent, slikeDestinacije );
            Globalna.nasaAgencija.Destinacije.Add(destinacija);
        }

        public List<String> dajListuDestinacija() 
        {
            List<String> lista = new List<string>();
            foreach(Destinacija d in Globalna.nasaAgencija.Destinacije) {
                lista.Add(d.Naziv + " - " + d.Drzava + " - " + d.Kontinent);
            }
            return lista;
        }
    }
}
