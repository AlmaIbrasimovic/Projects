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
    public sealed partial class Doktor : Page
    {
        public Doktor()
        {
            this.InitializeComponent();
            ime.Visibility = Visibility.Collapsed;
            pacijent.Visibility = Visibility.Collapsed;
            terapije.Visibility = Visibility.Collapsed;
            blok.Visibility = Visibility.Collapsed;
            tip.Visibility = Visibility.Collapsed;
            datum.Visibility = Visibility.Collapsed;
            tipT.Visibility = Visibility.Collapsed;
            datumT.Visibility = Visibility.Collapsed;
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((Boolean)pregled.IsChecked)
                {
                    if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                    {
                        throw new Exception("Nije registrovan niti jedan pacijent. Ne može se zakazati pregled!");
                    }
                    bool imaKreiran = false;
                    string novi = pacijent.SelectedItem.ToString();
                    novi = novi.Substring(0, 13);
                    if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                    if (!imaKreiran)
                    {      
                        throw new Exception("Nije kreiran karton za tog pacijenta! Kreirajte");
                    }
                    if (tipT.SelectedIndex < 0)
                    { 
                        throw new Exception("Nepotpuni podaci!");
                    }
                    if (blok.Text.Length == 0)
                    {       
                        throw new Exception("Nepotpuni podaci!");
                    }
                   
                    Pregled pregled = new Pregled(tipT.SelectedItem.ToString(), datumT.Date.Value.Date, novi, Convert.ToDouble(blok.Text));         
                    globalnaKlasa.klinika17270.registrujNoviPregled(pregled);
                    var dialog = new MessageDialog("Pregled uspješno zakazan!");
                    dialog.ShowAsync(); 
                }
                else if ((Boolean)terapija.IsChecked)
                {
                    if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                    {
                        throw new Exception("Nije registrovan niti jedan pacijent. Ne mogu se ažurirati terapije!");
                    }
                    bool imaKreiran = false;
                    string novi = pacijent.SelectedItem.ToString();
                    novi = novi.Substring(0, 13);
                    if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                    if (!imaKreiran)
                    {                    
                        throw new Exception("Ne postoji kreiran karton za tog pacijenta!");
                    }
                    if (blok.Text.Length == 0)
                    {               
                        throw new Exception("Nepotpuni podaci");
                    }         
                    List<string> terapije = new List<string>();
                    string[] linije = blok.Text.Split('\n');
                    foreach (var VARIABLE in linije)
                    {
                        terapije.Add(VARIABLE);
                    }
                    globalnaKlasa.klinika17270.azurirajTerapije(terapije, novi);
                    var dialog = new MessageDialog("Terapije uspješno ažurirane!");
                    dialog.ShowAsync();
                }  
            }
            catch (Exception ec)
            {
                var dialog = new MessageDialog(ec.Message);
                dialog.ShowAsync();
            }
        }

        private void pregled_Checked(object sender, RoutedEventArgs e)
        {
            pacijent.Items.Clear();
            foreach (var VARIABLE in globalnaKlasa.registrovaniPacijenti)
            {
                string temp = VARIABLE.Key;
                temp += " " + VARIABLE.Value.Item1;
                temp += " " + VARIABLE.Value.Item2;
                pacijent.Items.Add(temp);
            }
            ime.Text = "Odaberite pacijenta:";
            blok.Visibility = Visibility.Visible;
            ime.Visibility = Visibility.Visible;
            pacijent.Visibility = Visibility.Visible;
            tip.Visibility = Visibility.Visible;
            datum.Visibility = Visibility.Visible;
            tipT.Visibility = Visibility.Visible;
            tipT.Items.Add("Ortopedski");
            tipT.Items.Add("Kardioloski");
            tipT.Items.Add("Dermatoloski");
            tipT.Items.Add("Internisticki");
            tipT.Items.Add("Otorinolaringoloski");
            tipT.Items.Add("Oftamoloski");
            tipT.Items.Add("Laboratorijski");
            tipT.Items.Add("Stomatoloski");

            datumT.Visibility = Visibility.Visible;
            terapije.Text = "Cijena:";
            terapije.Visibility = Visibility.Visible;
        }

        private void terapija_Checked(object sender, RoutedEventArgs e)
        {
            ime.Text = "Odaberite pacijenta:";
            ime.Visibility = Visibility.Visible;
            terapije.Text = "Terapije:";
            terapije.Visibility = Visibility.Visible;
            blok.Visibility = Visibility.Visible;
            blok.Text = "";
            pacijent.Items.Clear();
            foreach (var VARIABLE in globalnaKlasa.registrovaniPacijenti)
            {
                string temp = VARIABLE.Key;
                temp += " " + VARIABLE.Value.Item1;
                temp += " " + VARIABLE.Value.Item2;
                pacijent.Items.Add(temp);
            }
            tip.Visibility = Visibility.Collapsed;
            datum.Visibility = Visibility.Collapsed;
            tipT.Visibility = Visibility.Collapsed;
            datumT.Visibility = Visibility.Collapsed; pacijent.Visibility = Visibility.Visible;
        }

        private void red_Checked(object sender, RoutedEventArgs e)
        {
            tip.Visibility = Visibility.Collapsed;
            datum.Visibility = Visibility.Collapsed;
            tipT.Visibility = Visibility.Collapsed;
            datumT.Visibility = Visibility.Collapsed;
            ime.Text = "Odaberite salu:";
            ime.Visibility = Visibility.Visible;
            pacijent.Visibility = Visibility.Visible;
            pacijent.Items.Clear();
            pacijent.Items.Add("Ortopedska");
            pacijent.Items.Add("Kardiološka");
            pacijent.Items.Add("Dermatološka");
            pacijent.Items.Add("Internistička");
            pacijent.Items.Add("Otorinolaringološka");
            pacijent.Items.Add("Oftamološka");
            pacijent.Items.Add("Laboratorija");
            pacijent.Items.Add("Stomatološka");
            terapije.Visibility = Visibility.Collapsed;
            blok.Visibility = Visibility.Visible;
            blok.Text = "";
        }
        private void pacijent_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pacijent.SelectedIndex >= 0)
            {
                if (pacijent.SelectedItem.Equals("Ortopedska"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.orto));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Kardiološka"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.kard));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Dermatološka"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.derma));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Internistička"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.inter));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Otorinolaringološka"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.otoro));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Oftamološka"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.ofta));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Laboratorija"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.lab));
                    blok.Text += (" pacijenata.");
                }
                if (pacijent.SelectedItem.Equals("Stomatološka"))
                {
                    blok.Text = "";
                    blok.Text += ("Trenutno čeka ");
                    blok.Text += (Convert.ToString(globalnaKlasa.stoma));
                    blok.Text += (" pacijenata.");
                }
            }
        }
    }
}
