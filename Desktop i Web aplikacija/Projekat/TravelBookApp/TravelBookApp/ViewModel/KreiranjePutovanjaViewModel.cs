using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelBookApp.AzureKlase;
using TravelBookApp.Model;
using Windows.UI.Xaml.Controls;

namespace TravelBookApp.ViewModel
{
    public class KreiranjePutovanjaViewModel
    {
        public static DestinacijaViewModel destinacijaVM = new DestinacijaViewModel();
        public static HotelViewModel hotelVM = new HotelViewModel();
      
        public void kreirajPutovanje(DateTime datumPolaska, DateTime datumPovratka, int minimalniBrojPutnika, int maximalniBrojPutnika, string opisPutovanja, bool istaknutoPutovanje, int idAgencije, Destinacija infoDestinacije, Hotel infoHotela, Prevoz infoPrevoza, Double cijenaPutovanja)
        {
            Putovanje putovanje =  new Putovanje(datumPolaska, datumPovratka, minimalniBrojPutnika, maximalniBrojPutnika, opisPutovanja, istaknutoPutovanje, idAgencije, infoDestinacije, infoHotela, infoPrevoza, cijenaPutovanja);
            Globalna.nasaAgencija.Putovanja.Add(putovanje);
        }
        public void dodajNoviHotel(string ime, int maximalniKapacitet, int kapacitet, Destinacija lokacija, double cijenaPoOsobi, Image slikeHotela = null)
        {
            Hotel h = new Hotel(ime, maximalniKapacitet, kapacitet, lokacija, cijenaPoOsobi, slikeHotela); 
            Globalna.nasaAgencija.Hoteli.Add(h);
        }

        public void dodajNovuDestinaciju(string naziv, String drzava, Kontinent kontinent, Image slikeDestinacije)
        {
            Destinacija de = new Destinacija(naziv, drzava, kontinent, slikeDestinacije);
            Globalna.nasaAgencija.Destinacije.Add(de);
        }      

        public List<String> dajListuBusevaPoDestinacijiIKapacitetu(String destinacija, int kapacitet) 
        {
            List<String> lista = new List<string>();
            foreach(Prevoz p in Globalna.nasaAgencija.Prevozi) {
                if (p.PrevozDestinacija.Equals(destinacija) && p.Kapacitet >= kapacitet) lista.Add(p.Ime + ", " + p.CijenaPoOsobi + "KM");
            }
            return lista;
        }

        public List<String> dajListuHotelaPoDestinaciji(String destinacija)
        {
            return hotelVM.dajListuNazivaHotelaPoLokaciji(destinacija);
        }
    }
}
