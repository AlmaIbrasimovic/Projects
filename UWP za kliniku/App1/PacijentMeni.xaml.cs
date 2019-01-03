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
using Zadaca1;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class PacijentMeni : Page
    {
        public PacijentMeni()
        {
            this.InitializeComponent();
            bool spol = false;
            string imePrezime = String.Empty;
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                if (VARIABLE._JMBG == globalnaKlasa.jmbgZaPacijenta)
                {
                    if (VARIABLE._Spol == "Žensko") spol = true;
                    imePrezime = VARIABLE._Ime + " " + VARIABLE._Prezime;
                }
            }
            if (spol) ko.Text = "Dobro došla, " + imePrezime;
            else ko.Text = "Dobrodošao, " + imePrezime;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pacijent));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(KartonPacijenta));
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(ZakazaniPregled));
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }
    }
}
