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
using Zadaca1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Brisanje : Page
    {
        public Brisanje()
        {
            this.InitializeComponent();
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                string podatak = VARIABLE._JMBG + " " + VARIABLE._Ime + " " + VARIABLE._Prezime;
                JMBG.Items.Add(podatak);
            }
            jmbg.Visibility = Visibility.Collapsed;
            JMBG.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ostali));
        }

        private void svi_Checked(object sender, RoutedEventArgs e)
        {
            jmbg.Visibility = Visibility.Collapsed;
            JMBG.Visibility = Visibility.Collapsed;
        }

        private void jedan_Checked(object sender, RoutedEventArgs e)
        {
            jmbg.Visibility = Visibility.Visible;
            JMBG.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (globalnaKlasa.klinika17270.ListaPacijenata.Count == 0)
                {
                    throw new Exception("Nema registrovanih pacijenata!");
                }
                if ((Boolean)svi.IsChecked)
                {
                    globalnaKlasa.klinika17270.ListaPacijenata.Clear();
                    var dialog = new MessageDialog("Pacijenti uspješno obrisani!");
                    dialog.ShowAsync();
                    JMBG.Items.Clear();
                }
                else if ((Boolean)jedan.IsChecked)
                {
                    string novi = JMBG.SelectedItem.ToString();
                    novi = novi.Substring(0, 13);
                    globalnaKlasa.klinika17270.izbrisiPacijenta(novi);
                    globalnaKlasa.klinika17270.izbrisiKarton(novi);
                    globalnaKlasa.registrovaniPacijenti.Remove(novi);
                    var dialog = new MessageDialog("Pacijent uspješno obrisan!");
                    dialog.ShowAsync();
                    JMBG.Items.Clear();
                    foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
                    {
                        string podatak = VARIABLE._JMBG + " " + VARIABLE._Ime + " " + VARIABLE._Prezime;
                        JMBG.Items.Add(podatak);
                    }  
                }
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                dialog.ShowAsync();
            }
        }
    }
}
