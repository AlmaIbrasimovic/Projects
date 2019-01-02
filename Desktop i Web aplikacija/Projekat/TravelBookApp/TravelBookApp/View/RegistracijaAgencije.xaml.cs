using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using TravelBookApp.ViewModel;
using TravelBookApp.Model;
using Microsoft.WindowsAzure.MobileServices;
using TravelBookApp.AzureKlase;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace TravelBookApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RegistracijaAgencije : Page
    {
        static RegistracijaViewModel r = new RegistracijaViewModel();
       
        public RegistracijaAgencije()
        {
            this.InitializeComponent();
            tTipKartice.Items.Add(VrstaKartice.VISA);
            tTipKartice.Items.Add(VrstaKartice.MasterCard);
            tTipKartice.Items.Add(VrstaKartice.AmericanExpress);
            tTipKartice.Items.Add(VrstaKartice.Discover);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Prijava));
        }

        private bool provjeriDatumIstekaKartice (string datum)
        {
            const int validnaDuzinaUnesenogDatuma = 5;
            if (datum.Length != validnaDuzinaUnesenogDatuma) return false;
            Boolean jelValidanDatum = datum[0] >= '0' && datum[1] <= '9' && datum[2] == '/' && datum[3] >= '1' && datum[4] <= '9';           
            return jelValidanDatum;
        }
        private void Dugme_RegistrujSe(object sender, RoutedEventArgs e)
        {           
            if (validacijaPodataka())
            {
                Kartica nova = new Kartica((VrstaKartice)tTipKartice.SelectedItem, tDatumIsteka.Text, tBrojKartice.Text, Convert.ToInt32(tCSC.Text));
                Globalna.nasaAgencija.Kartice.Add(nova);
                KarticaAzure kart = new KarticaAzure();               
                kart.dodajKarticu(nova);
                bool jesulIsteSifre = tSifra.Password.ToString().Equals(tSifraPonovo.Password.ToString());
                if (jesulIsteSifre)
                {
                    Agencija agencija = new Agencija(tNaziv.Text, nova, tTelefon.Text, tMail.Text, tGrad.Text, tAdresa.Text, tSifra.Password.ToString());
                    r.registrujAgneciju(agencija);
                    try
                    {
                        AgencijaAzure agencijaAzure = new AgencijaAzure();
                        agencijaAzure.dodajAgenciju(agencija);
                        var dialog = new MessageDialog("Uspješno ste registrovali agenciju!");
                        dialog.ShowAsync();
                    }
                    catch (Exception ex)
                    {
                        MessageDialog msgDialogError = new MessageDialog("Error : " + ex.ToString());
                        msgDialogError.ShowAsync();
                    }                       
                    Frame.Navigate(typeof(Prijava));
                }
                else
                {
                    r.Poruka = new MessageDialog("Pogrešna šifra! Pokušajte ponovno.");
                    r.Poruka.ShowAsync();
                }              
            } 
            
            bool validacijaPodataka()
            {
                bool jelOK = true;
                if (tCSC.Text.Length == 3)
                {
                    jelOK = true;
                    greska.Visibility = Visibility.Collapsed;
                }
                if (tDatumIsteka.Text.Length != 0)
                {
                    if (provjeriDatumIstekaKartice(tDatumIsteka.Text))
                    {
                        greska1.Visibility = Visibility.Collapsed;
                        jelOK = true;
                    }
                }
                if (tTipKartice.SelectedIndex >= 0)
                {
                    greska2.Visibility = Visibility.Collapsed;
                    jelOK = true;

                }
                if (tNaziv.Text.Length != 0 && tTelefon.Text.Length != 0 && tGrad.Text.Length != 0 && tAdresa.Text.Length != 0 && tMail.Text.Length != 0 && tBrojKartice.Text.Length != 0) jelOK = true;

                //Ukoliko validacija nije uredu
                if (tCSC.Text.Length != 3)
                {
                    jelOK = false;
                    greska.Visibility = Visibility.Visible;
                }
                if (tDatumIsteka.Text.Length == 0)
                {
                    greska1.Visibility = Visibility.Visible;
                    jelOK = false;
                }
                if (tDatumIsteka.Text.Length != 0)
                {
                    if (!provjeriDatumIstekaKartice(tDatumIsteka.Text))
                    {
                        greska1.Visibility = Visibility.Visible;
                        jelOK = false;
                    }
                }
                if (tTipKartice.SelectedIndex < 0)
                {
                    greska2.Visibility = Visibility.Visible;
                    jelOK = false;

                }
                if (tNaziv.Text.Length == 0 || tTelefon.Text.Length == 0 || tGrad.Text.Length == 0 || tAdresa.Text.Length == 0 || tMail.Text.Length == 0 || tBrojKartice.Text.Length == 0)
                {
                    var dialog = new MessageDialog("Nisu popunjena sva polja!");
                    dialog.ShowAsync();
                    jelOK = false;
                }

                return jelOK;
            }
        }
    }
}
