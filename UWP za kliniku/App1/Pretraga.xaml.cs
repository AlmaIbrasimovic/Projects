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
    public sealed partial class Pretraga : Page
    {
        public Pretraga()
        {
            this.InitializeComponent();
            label.Visibility = Visibility.Collapsed;
            jmbg.Visibility = Visibility.Collapsed;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Boolean)karton.IsChecked)
                {
                    bool ima = false;
                    int duzina = duzina = jmbg.Text.Length;
                    foreach ( var karton in globalnaKlasa.klinika17270.ListaKartona)
                    {
                        if (karton.Jmbg == jmbg.Text) ima = true;
                    }
                    if (!ima)
                    {
                        throw new Exception("Ne postoji karton pacijenta sa tim JMBG-om!");
                    }
                    if (duzina == 0)
                    {           
                        throw new Exception("Nepotpuni podaci!");
                    }
                    globalnaKlasa.jmbgZaDoktora = jmbg.Text;
                    Frame.Navigate(typeof(glavni));
                }
                else if ((Boolean)svi.IsChecked)
                {
                    Frame.Navigate(typeof(sviPacijenti));
                }
            }
            catch (Exception ec)
            {
                var dialog = new MessageDialog(ec.Message);
                dialog.ShowAsync();
            } 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ostali));
        }

        private void karton_Checked(object sender, RoutedEventArgs e)
        {
            label.Visibility = Visibility.Visible;
            jmbg.Visibility = Visibility.Visible;
        }

        private void svi_Checked(object sender, RoutedEventArgs e)
        {
            label.Visibility = Visibility.Collapsed;
            jmbg.Visibility = Visibility.Collapsed;
        }
    }
}
