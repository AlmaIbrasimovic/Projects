using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using TravelBookApp.ViewModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TravelBookApp.Model;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    public sealed partial class PocetnaStranica : Page
    {
        static AgencijaViewModel agencija = new AgencijaViewModel();
        public PocetnaStranica()
        {
            Agencija a = agencija.vratiAgenciju();
            this.InitializeComponent();
            tNazivT.Text= "Naziv agencije:  " + a.NazivAgencije;
            tKontaktTel.Text = "Kontakt telefon:  " + a.KontaktTelefon;
            tLokacija.Text = "Adresa:  " + a.Lokacija + "\nGrad: " + a.Grad;
            tEmail.Text = "E-mail adresa: " + a.EmailAdresa;           
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Prijava));
        }

        private void bKreirajPutovanje_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KreiranjePutovanja));
        }

        private void bPregledHistorije_Click(object sender, RoutedEventArgs e)
        {
            Globalna.trenutnaPutovanja = false;
            Frame.Navigate(typeof(PrethodnaPutovanja));
        }

        private void bPregledPutovanja_Click(object sender, RoutedEventArgs e)
        {
            Globalna.trenutnaPutovanja = true;
            Frame.Navigate(typeof(PrethodnaPutovanja));
        }
    }
}
