using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.Model;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.ViewModel
{
    public class HotelViewModel
    {
        public void dodajHotel(string ime, int maximalniKapacitet, int kapacitet, Destinacija lokacija, double cijenaPoOsobi, Image slikeHotela = null) {
          Hotel hotel =  new Hotel(ime, maximalniKapacitet, kapacitet, lokacija, cijenaPoOsobi, slikeHotela);
            Globalna.nasaAgencija.Hoteli.Add(hotel);
        }

        public List<String> dajListuNazivaHotelaPoLokaciji(String destinacija)
        {
            List<String> lista = new List<string>();
            foreach(Hotel h in Globalna.nasaAgencija.Hoteli) {
                if (h.Lokacija.Naziv == destinacija) lista.Add(h.Ime);
            }
            return lista;
        }
    }
}
