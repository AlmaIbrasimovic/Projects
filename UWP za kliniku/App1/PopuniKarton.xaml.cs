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
    public sealed partial class PopuniKarton : Page
    {
        public PopuniKarton()
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
                if (globalnaKlasa.registrovaniPacijenti.Count != 0)
                {
                    bool imaKreiran = false;
                    string novi = odabir.SelectedItem.ToString();
                    novi = novi.Substring(0, 13);
                    if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                    if (!imaKreiran)
                    {
                        throw new Exception ("Nije kreiran karton za tog pacijenta!");
                    }
                }
                if (bolesti.Text.Length == 0 || alergije.Text.Length == 0 || terapije.Text.Length == 0 || misljenja.Text.Length == 0)
                {
                    throw new Exception("Polja ne smiju biti prazna!");
                }
                if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                {  
                    throw new Exception("Nema registrovanih pacijenata!");
                }
                if (odabir.SelectedIndex < 0 || alergije.Text.Length == 0 || bolesti.Text.Length == 0 || misljenja.Text.Length == 0 || terapije.Text.Length == 0)
                {          
                    throw new Exception("Nepotpuni podaci");
                }
                List<string> bolesti1 = new List<string>();
                List<string> alergije1 = new List<string>();
                List<string> terapije1 = new List<string>();
                List<string> misljenja1 = new List<string>();
                bolesti1.Clear();
                alergije1.Clear();
                terapije1.Clear();
                misljenja1.Clear();
                bolesti1.Add(bolesti.Text);
                alergije1.Add(alergije.Text);
                misljenja1.Add(misljenja.Text);
                terapije1.Add(terapije.Text);
                string imePrezime = odabir.SelectedItem.ToString();
                int vel = Convert.ToInt32(odabir.SelectedItem.ToString().Length - 1);
                imePrezime = imePrezime.Substring(14, vel - 13);
                string noviJMBG = odabir.SelectedItem.ToString();
                noviJMBG = noviJMBG.Substring(0, 13);
                Karton karton = new Karton(imePrezime, noviJMBG, dat.Date.Value.Date, bolesti1, alergije1, misljenja1, terapije1);
                globalnaKlasa.klinika17270.kreirajKarton(karton);
                var dialog = new MessageDialog("Karton uspješno popunjen!");
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
