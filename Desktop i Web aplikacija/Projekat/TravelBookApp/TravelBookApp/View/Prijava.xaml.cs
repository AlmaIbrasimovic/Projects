using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using TravelBookApp.ViewModel;
using System.Data;
using System.Data.SqlClient;

using Windows.ApplicationModel.Core;
using TravelBookApp.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;
using TravelBookApp.AzureKlase;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Prijava : Page
    {
        static LoginViewModel l = new LoginViewModel();
        public Prijava()
        {
           this.InitializeComponent();
           // upisiDummyPodatke(); Pozvati ukoliko je baza za hotele, prevoze i destinacije prazna.
            if (Globalna.nasaAgencija.Putovanja.Count == 0 && Globalna.nasaAgencija.Agencije.Count == 0) ucitajBazuUwp();
        }

        private void ucitajBazuUwp()
        {
            AgencijaAzure a = new AgencijaAzure();
            DestinacijaAzure d = new DestinacijaAzure();
            HotelAzure h = new HotelAzure();
            KarticaAzure k = new KarticaAzure();
            PrevozAzure l = new PrevozAzure();
            PutovanjeAzure p = new PutovanjeAzure();
            k.UcitajKartice();
            a.UcitajAgencije();
            d.UcitajDestinacije();
            h.UcitajHotele();
           
            l.UcitajPrevoze();
            p.UcitajPutovanja();

            if(Globalna.nasaAgencija.Agencije.Count != 0) Globalna.idSvihAgencija = Globalna.nasaAgencija.Agencije.Count;
            if (Globalna.nasaAgencija.Putovanja.Count != 0) Globalna.idSvihPutovanja = Globalna.nasaAgencija.Putovanja.Count;
            if (Globalna.nasaAgencija.Kartice.Count != 0) Globalna.idSvihKartica = Globalna.nasaAgencija.Kartice.Count;
            if (Globalna.nasaAgencija.Hoteli.Count != 0) Globalna.idSvihHotela = Globalna.nasaAgencija.Hoteli.Count;
            if (Globalna.nasaAgencija.Prevozi.Count != 0) Globalna.idSvihPrevoza = Globalna.nasaAgencija.Prevozi.Count;
            if (Globalna.nasaAgencija.Destinacije.Count != 0) Globalna.idSvihDestinacija = Globalna.nasaAgencija.Destinacije.Count;
            if (Globalna.nasaAgencija.Korisnici.Count != 0) Globalna.idSvihKorisnika = Globalna.nasaAgencija.Korisnici.Count;
        }

        private void bPrijava_Click(object sender, RoutedEventArgs e)
        {
            if (l.prijaviAgenciju(tNaziv.Text, bSifra.Password.ToString())) {
              Frame.Navigate(typeof(PocetnaStranica));
            }
            else {
                l.Poruka = new Windows.UI.Popups.MessageDialog("Agencija ne postoji ili su podaci netačni.");
                l.Poruka.ShowAsync();
            }
        }

        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(RegistracijaAgencije));
        }

        private void bOdustani_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        public void upisiDummyPodatke()
        {
            //Destinacije i hoteli
            Destinacija prva = new Destinacija("Sarajevo", "Bosna i Hercegovina", Kontinent.Evropa);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            Hotel h = new Hotel("Radon Plaza", 600, 30, prva, 150);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Zagreb", "Hrvatska", Kontinent.Evropa);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Evropa", 300, 100, prva, 100);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Tokio", "Japan", Kontinent.Azija);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Hokaido Hotel", 500, 30, prva, 250);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Seul", "Južna Koreja", Kontinent.Azija);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Husha Kusha", 200, 70, prva, 450);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Kairo", "Egipat", Kontinent.Afrika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Mumija", 600, 530, prva, 250);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Adis Abeba", "Etiopija", Kontinent.Afrika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Utopija", 400, 200, prva, 550);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Otava", "Kanada", Kontinent.SjevernaAmerika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Hohol", 450, 100, prva, 650);
            Globalna.nasaAgencija.Hoteli.Add(h);

            prva = new Destinacija("Rio de Janeiro", "Brazil", Kontinent.JuznaAmerika);
            Globalna.nasaAgencija.Destinacije.Add(prva);

            h = new Hotel("Fulon", 600, 400, prva, 1000);
            Globalna.nasaAgencija.Hoteli.Add(h);

            //Dodavanje prevoza

            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 80, 30, 50, "Tokio"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Centro", VrstaPrevoza.autobus, 150, 80, 100, "Sarajevo"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("VanBus", VrstaPrevoza.autobus, 50, 30, 70, "Otava"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 220, 70, 90, "Kairo"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 130, 45, 75, "Zagreb"));
            Globalna.nasaAgencija.Prevozi.Add(new Prevoz("Globus", VrstaPrevoza.autobus, 100, 90, 60, "Rio de Janeiro"));

            DestinacijaAzure d = new DestinacijaAzure();
            foreach (Destinacija des in Globalna.nasaAgencija.Destinacije) d.dodajDestinaciju(des);
            HotelAzure ho = new HotelAzure();
            foreach (Hotel hot in Globalna.nasaAgencija.Hoteli) ho.dodajHotel(hot);
            PrevozAzure pr = new PrevozAzure();
            foreach (Prevoz prev in Globalna.nasaAgencija.Prevozi) pr.dodajPrevoz(prev);
        }
    }
}
