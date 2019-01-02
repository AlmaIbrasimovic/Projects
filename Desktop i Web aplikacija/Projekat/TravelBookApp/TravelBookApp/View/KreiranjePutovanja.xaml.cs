using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
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
using TravelBookApp.ViewModel;
using Windows.UI.Popups;
using Windows.UI;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.WindowsAzure.MobileServices;
using TravelBookApp.AzureKlase;
using System.Diagnostics;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TravelBookApp
{
    public sealed partial class KreiranjePutovanja : Page
    {
        static KreiranjePutovanjaViewModel putovanjeVM = new KreiranjePutovanjaViewModel();
        List<String> naziviDestinacija = new List<string>();
        List<String> naziviHotela = new List<string>();
        List<String> autobusi = new List<string>();
        String odabraniHotel;
        Boolean istaknuto;     

        public KreiranjePutovanja()
        {
            this.InitializeComponent();
            gLet.Visibility = Visibility.Collapsed;

            cKontinent.Items.Add("Afrika");
            cKontinent.Items.Add("Antartika");
            cKontinent.Items.Add("Australija");
            cKontinent.Items.Add("Azija");
            cKontinent.Items.Add("Evropa");
            cKontinent.Items.Add("Južna Amerika");
            cKontinent.Items.Add("Sjeverna Amerika");

            cDestinacije.Items.Clear();
            cHoteli.Items.Clear();
            cPrevoz.Items.Clear();
            gDestinacija.Visibility = Visibility.Collapsed;
            foreach (var dest in Globalna.nasaAgencija.Destinacije) {
                cDestinacije.Items.Add(dest.Naziv);
            }
            cDestinacije.Items.Add("Ništa od ponuđenog");
            gHotel.Visibility = Visibility.Collapsed;
            if(naziviDestinacija.Count == 0) naziviDestinacija.Add("Nijedna od ponuđenih");  
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {   
            Frame.Navigate(typeof(PocetnaStranica));
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (rAvion.IsChecked == true) gLet.Visibility = Visibility.Visible;          
            else gLet.Visibility = Visibility.Collapsed;
        }

        private void cDestinacije_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string odabrano = cDestinacije.SelectedItem.ToString();
            if (odabrano.Equals("Ništa od ponuđenog")) gDestinacija.Visibility = Visibility.Visible;
            naziviHotela.Clear();
            naziviHotela = putovanjeVM.dajListuHotelaPoDestinaciji(odabrano);
            cHoteli.Items.Clear();
            foreach (var temp in naziviHotela) cHoteli.Items.Add(temp);
            if (odabrano != "Ništa od ponuđenog"){
                cHoteli.Items.Add("Ništa od ponuđenog");
                gDestinacija.Visibility = Visibility.Collapsed;
            }     
        }

        private void cHoteli_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string odabrano = string.Empty;
            if(cHoteli.SelectedIndex > -1) odabrano = cHoteli.SelectedItem.ToString();
            if (odabrano.Equals("Ništa od ponuđenog")) gHotel.Visibility = Visibility.Visible;
            else gHotel.Visibility = Visibility.Collapsed;
            if (cHoteli.SelectedItem.ToString() != "Ništa od ponuđenog") odabraniHotel = naziviHotela[cHoteli.SelectedIndex];
        }

        private bool validacijaPodataka()
        {
            Boolean jelOK = true;
            if (sMin.Value <= sMax.Value)
            {
                jelOK = true;
                greska.Visibility = Visibility.Collapsed;
                minBroj.Foreground = new SolidColorBrush(Colors.Black);
                maxBroj.Foreground = new SolidColorBrush(Colors.Black);
            }
            if (dPolaska.Date < dPovratka.Date)
            {
                jelOK = true;
                greska8.Visibility = Visibility.Collapsed;
            }
            if (rDA.IsChecked == true || rNE.IsChecked == true)
            {
                greska1.Visibility = Visibility.Collapsed;
                jelOK = true;
            }
            if (!String.IsNullOrEmpty(tCijena.Text))
            {
                jelOK = true;
                greska5.Visibility = Visibility.Collapsed;
            }
            if (cPrevoz.SelectedIndex != -1)
            {
                jelOK = true;
                greska4.Visibility = Visibility.Collapsed;
            }
            if (cHoteli.SelectedIndex != -1)
            {
                jelOK = true;
                greska3.Visibility = Visibility.Collapsed;
            }
            if (rAvion.IsChecked == true)
            {
                if (comboBox.SelectedIndex != -1)
                {
                    jelOK = true;
                    greska6.Visibility = Visibility.Collapsed;
                }
                if (comboBox1.SelectedIndex != -1)
                {
                    jelOK = true;
                    greska7.Visibility = Visibility.Collapsed;
                }
            }
            if (sMin.Value > sMax.Value)
            {
                jelOK = false;
                greska.Visibility = Visibility.Visible;
                minBroj.Foreground = new SolidColorBrush(Colors.Red);
                maxBroj.Foreground = new SolidColorBrush(Colors.Red);
            }
            if (rDA.IsChecked == false && rNE.IsChecked == false)
            {
                greska1.Visibility = Visibility.Visible; //AKTIVACIJA textBloc-a KOJI PRIKAZUJE GREŠKU, KAO errorProvider
                jelOK = false;
            }
            if (dPolaska.Date > dPovratka.Date)
            {
                jelOK = false;
                greska8.Visibility = Visibility.Visible;
            }
            if (String.IsNullOrEmpty(tCijena.Text))
            {
                jelOK = false;
                greska5.Visibility = Visibility.Visible;
            }
            if (cPrevoz.SelectedIndex == -1)
            {
                jelOK = false;
                greska4.Visibility = Visibility.Visible;
            }
            if (cHoteli.SelectedIndex == -1)
            {
                jelOK = false;
                greska3.Visibility = Visibility.Visible;
            }
            if (rAvion.IsChecked == true)
            {
                if (comboBox.SelectedIndex == -1)
                {
                    jelOK = false;
                    greska6.Visibility = Visibility.Visible;
                }
                if (comboBox1.SelectedIndex == -1)
                {
                    jelOK = false;
                    greska7.Visibility = Visibility.Visible;
                }
            }
            return jelOK;

        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Prevoz prevoz = null;
            string odabranaDestinacija = cDestinacije.SelectedItem.ToString();
            string odabraniHotel = cHoteli.SelectedItem.ToString();
            if (rAutobus.IsChecked == true) {
                foreach (Prevoz p in Globalna.nasaAgencija.Prevozi) {
                    if (p.Ime.Equals(autobusi[cPrevoz.SelectedIndex].Substring(0, autobusi[cPrevoz.SelectedIndex].IndexOf(","))) && p.PrevozDestinacija.Equals(odabranaDestinacija)) prevoz = p;
                }
            }
            else prevoz = null;
            Boolean jelOK = validacijaPodataka();
            if (!jelOK) {
                var dialog = new MessageDialog("Postoje greške. Popravite pa ponovo kreirajte!");
                dialog.ShowAsync();
            }

            Destinacija novaDestinacija = new Destinacija("random", "random", Kontinent.Evropa);
            if (odabranaDestinacija != ("Ništa od ponuđenog")) novaDestinacija = Globalna.nasaAgencija.Destinacije[cDestinacije.SelectedIndex];
            if (odabranaDestinacija.Equals("Ništa od ponuđenog"))
            {
                Kontinent kon = new Kontinent();
                if (cKontinent.SelectedItem.ToString().Equals("Evropa")) kon = Kontinent.Evropa;
                if (cKontinent.SelectedItem.ToString().Equals("Azija")) kon = Kontinent.Azija;
                if (cKontinent.SelectedItem.ToString().Equals("Afrika")) kon = Kontinent.Afrika;
                if (cKontinent.SelectedItem.ToString().Equals("Sjeverna Amerika")) kon = Kontinent.SjevernaAmerika;
                if (cKontinent.SelectedItem.ToString().Equals("Južna Amerika")) kon = Kontinent.JuznaAmerika;
                if (cKontinent.SelectedItem.ToString().Equals("Antartika")) kon = Kontinent.Antartika;
                if (cKontinent.SelectedItem.ToString().Equals("Australija")) kon = Kontinent.Australija;
                novaDestinacija = new Destinacija(tDestinacija.Text, tDrzava.Text, kon, iSlikaDestinacije);
                putovanjeVM.dodajNovuDestinaciju(tDestinacija.Text, tDrzava.Text, kon, iSlikaDestinacije);         
                DestinacijaAzure d = new DestinacijaAzure();
                d.dodajDestinaciju(novaDestinacija);
            }
            Hotel noviHotel = Globalna.nasaAgencija.Hoteli[cHoteli.SelectedIndex];
            if (odabraniHotel.Equals("Ništa od ponuđenog")) {
                putovanjeVM.dodajNoviHotel(tHotel.Text, 300, Convert.ToInt32(300 - sMax.Value), novaDestinacija, 120, iSlikaHotela);
                noviHotel = new Hotel(tHotel.Text, 500, Convert.ToInt32(500 - sMax.Value), novaDestinacija, 120, iSlikaHotela);
                HotelAzure h = new HotelAzure();
                h.dodajHotel(noviHotel);
            }
            else {
                foreach (Hotel h in Globalna.nasaAgencija.Hoteli)
                {
                    if (h.Ime.Equals(cHoteli.SelectedItem))
                    {
                        noviHotel = h;
                        break;
                    }
                }
            }
            
            if (jelOK)
            {
                putovanjeVM.kreirajPutovanje(dPolaska.Date.Value.Date, dPovratka.Date.Value.Date, Convert.ToInt32(sMin.Value), Convert.ToInt32(sMax.Value), "opis putovanja", istaknuto, Globalna.prijavljenaAgencijaId, novaDestinacija, noviHotel, prevoz, Convert.ToDouble(tCijena.Text));             
                PutovanjeAzure p = new PutovanjeAzure();
                p.dodajPutovanje(Globalna.nasaAgencija.Putovanja[Globalna.nasaAgencija.Putovanja.Count - 1]);
                var dialog = new MessageDialog("Putovanje uspješno kreirano!");
                dialog.ShowAsync();
            } 
        }       

        private void bDodajHotel_Click(object sender, RoutedEventArgs e)
        {
            putovanjeVM.dodajNoviHotel(tHotel.Text, Convert.ToInt32(sMax.Value), Convert.ToInt32(sMin.Value), Globalna.nasaAgencija.Destinacije[cDestinacije.SelectedIndex], Convert.ToDouble(100), null);
        }

       private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
       {
            istaknuto = true;
       }
        
        private void rAutobus_Checked(object sender, RoutedEventArgs e)
        {
            string destinacija = string.Empty;
            string odabrano = cDestinacije.SelectedItem.ToString();
            if (odabrano.Equals("Ništa od ponuđenog")) destinacija = tDestinacija.Text;
            if (odabrano != "Ništa od ponuđenog") destinacija = cDestinacije.SelectedItem.ToString();
            autobusi = putovanjeVM.dajListuBusevaPoDestinacijiIKapacitetu(destinacija, Convert.ToInt32(sMax.Value));
            cPrevoz.Items.Clear();
            foreach (var temp in autobusi) cPrevoz.Items.Add(temp);
            gLet.Visibility = Visibility.Collapsed;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            istaknuto = false;
        }
        private void bDodajDestinaciju_Click_1(object sender, RoutedEventArgs e)
        {
            putovanjeVM.dodajNovuDestinaciju(tDestinacija.Text, "-", Kontinent.Afrika, null); 
        }
      
        private async void bUcitajHotel_Click(object sender, RoutedEventArgs e)
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.FileTypeFilter.Add(".jpeg");
            fileOpenPicker.FileTypeFilter.Add(".bmp");
            var storageFile = await fileOpenPicker.PickSingleFileAsync();

            if (storageFile != null) {
                using (IRandomAccessStream fileStream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read)) {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(fileStream);
                    iSlikaHotela.Visibility = Visibility.Visible;
                    iSlikaHotela.Source = bitmapImage;
                }
            }           
        }

        private void cPrevoz_SelectionChanged(object sender, SelectionChangedEventArgs e) { }
        private void sMax_ValueChanged(object sender, RangeBaseValueChangedEventArgs e) { }
        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e) { }
        private async void bUcitajSliku_Click(object sender, RoutedEventArgs e)
        {
            var fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".png");
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.FileTypeFilter.Add(".jpeg");
            fileOpenPicker.FileTypeFilter.Add(".bmp");
            var storageFile = await fileOpenPicker.PickSingleFileAsync();

            if (storageFile != null) {
                using (IRandomAccessStream fileStream = await storageFile.OpenAsync(Windows.Storage.FileAccessMode.Read)) {
                    BitmapImage bitmapImage = new BitmapImage();
                    await bitmapImage.SetSourceAsync(fileStream);
                    iSlikaDestinacije.Visibility = Visibility.Visible;
                    iSlikaDestinacije.Source = bitmapImage;
                }
            }
        }

        private void tDestinacija_TextChanged(object sender, TextChangedEventArgs e) { }

        private void cKontinent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string destinacija = tDestinacija.Text;
            foreach (var temp in putovanjeVM.dajListuHotelaPoDestinaciji(destinacija)) cHoteli.Items.Add(temp);
            cHoteli.Items.Add("Ništa od ponuđenog");
        }
    }
}
