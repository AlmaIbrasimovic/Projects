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
    public sealed partial class Registracija : Page
    {
        public Registracija()
        {
            this.InitializeComponent();
           
            /* klijent = Controls.OfType<MdiClient>().First();
             klijent.GotFocus += (s, e) => {
                 if (!MdiChildren.Any(x => x.Visible)) klijent.SendToBack();
             };*/
            tip.Items.Add("Hitni slučaj");
          
            tip.Items.Add("Normalni slučaj");
            spol.Items.Add("Muško");
            spol.Items.Add("Žensko");
            brak.Items.Add("Oženjen/udata");
            brak.Items.Add("Razveden/a");
            brak.Items.Add("Udovac/udovica");
            brak.Items.Add("Slobodan/slobodna");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ime.Text.Length == 0 || prezime.Text.Length == 0 || rod.Date.Value.Date == null || prijem.Date.Value.Date == null || spol.SelectedIndex < 0 || tip.SelectedIndex < 0 || brak.SelectedIndex < 0)
                {
                    throw new Exception("Polja ne smiju biti prazna!");
                }
                if (tip.SelectedItem.Equals("Normalni slučaj"))
                {
                    NormalniSlucajevi pac = new NormalniSlucajevi(ime.Text, prezime.Text, rod.Date.Value.Date,
                    jmbg.Text, spol.SelectedItem.ToString(), prijem.Date.Value.Date, brak.SelectedItem.ToString());
                    globalnaKlasa.klinika17270.registrujNovogPacijenta(pac);
                }
                else if (tip.SelectedItem.Equals("Hitni slučaj"))
                {
                    HitniSlucajevi pac = new HitniSlucajevi(ime.Text, prezime.Text, rod.Date.Value.Date,
                    jmbg.Text, spol.SelectedItem.ToString(), prijem.Date.Value.Date, brak.SelectedItem.ToString());
                    globalnaKlasa.klinika17270.registrujNovogPacijenta(pac);
                }
                Tuple<string, string> podaci = new Tuple<string, string>(ime.Text, prezime.Text);
                globalnaKlasa.registrovaniPacijenti.Add(jmbg.Text, podaci);
                var dialog = new MessageDialog("Pacijent registrovan uspješno!");
                dialog.ShowAsync();
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
    }
}
