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
    public sealed partial class glavni : Page
    {
        public glavni()
        {
            this.InitializeComponent();
            string ime = String.Empty;
            string prezime = string.Empty;
            string spol = String.Empty;
            string bracno = String.Empty;
            DateTime datumRodjenja = DateTime.Now;
            DateTime datumPregleda = DateTime.Now;
        
            List<string> bolesti = new List<string>();
            List<string> terapije = new List<string>();
            List<string> misljenja = new List<string>();
            List<string> alergije = new List<string>();
            
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                if (VARIABLE._JMBG == globalnaKlasa.jmbgZaDoktora)
                {
                    ime = VARIABLE._Ime;
                    prezime = VARIABLE._Prezime;
                    datumRodjenja = VARIABLE._datumRodjenja;
                    spol = VARIABLE._Spol;
                    bracno = VARIABLE.Brak;   
                }
            }
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaKartona)
            {
                if (VARIABLE.Jmbg == globalnaKlasa.jmbgZaDoktora)
                {
                    datumPregleda = VARIABLE.DatumZadnjegPregleda;
                    foreach (var VARIABLE1 in VARIABLE.ListaBolesti)
                    {
                        bolesti.Add(VARIABLE1);
                        bolesti.Add("\n");
                    }
                    foreach (var VARIABLE1 in VARIABLE.ListaAlergija)
                    {
                        alergije.Add(VARIABLE1);
                        alergije.Add("\n");
                    }
                    foreach (var VARIABLE1 in VARIABLE.ListaTerapija)
                    {
                        terapije.Add(VARIABLE1);
                        terapije.Add("\n");
                    }
                    foreach (var VARIABLE1 in VARIABLE.MisljenjaDoktora)
                    {
                        misljenja.Add(VARIABLE1);
                        misljenja.Add("\n");
                    }
                }
            }
            ime1.Text = ime;
            prezime1.Text = prezime;
            rod.Date = datumRodjenja;
            spol1.Text = spol;
            jmbg1.Text = globalnaKlasa.jmbgZaDoktora;
            brak1.Text = bracno;
            zadnji.Date = datumPregleda;
          
            foreach (var VARIABLE in alergije)
            {
                alergije1.Text += (VARIABLE);
            }
            foreach (var VARIABLE in bolesti)
            {
                bolesti1.Text += (VARIABLE);
            }
            foreach (var VARIABLE in terapije)
            {
                terapije1.Text += (VARIABLE);
            }
            foreach (var VARIABLE in misljenja)
            {
                misljenja1.Text += (VARIABLE);
            }
          
        }
    

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Pretraga));
        }

        private void misljenja_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
