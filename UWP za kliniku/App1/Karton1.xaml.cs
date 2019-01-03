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
    public sealed partial class Karton1 : Page
    {
        public Karton1()
        {
            this.InitializeComponent();
            foreach (var VARIABLE in globalnaKlasa.registrovaniPacijenti)
            {
                string temp = VARIABLE.Key;
                temp += " " + VARIABLE.Value.Item1;
                temp += " " + VARIABLE.Value.Item2;
                odabir.Items.Add(temp);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                {   
                    throw new Exception("Nema registrovanih pacijenata!");
                }
               
                if (odabir.SelectedIndex < 0)
                {
                    throw new Exception("Niste odabrali pacijenta!");
                }
                string jmbg = odabir.SelectedItem.ToString();
                jmbg = jmbg.Substring(0, 13);
                globalnaKlasa.klinika17270.listaJMBGZaKartone(jmbg);
                var dialog = new MessageDialog("Karton je uspješno kreiran!");
                dialog.ShowAsync();

            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                dialog.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Ostali));
        }
    }
}
