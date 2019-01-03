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
    public sealed partial class Pacijent : Page
    {
        public Pacijent()
        {
            this.InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                bool ima = false;
                foreach (var karton in globalnaKlasa.klinika17270.ListaKartona)
                {
                    if (karton.Jmbg == jmbg.Text) ima = true;
                }
                if (!ima)
                {   
                    throw new Exception("Nepostojeći JMBG!");
                }
                if (jmbg.Text.Length == 0)
                { 
                    throw new Exception("Nepotpuni podaci!");
                }    
                globalnaKlasa.jmbgZaPacijenta = jmbg.Text;
                Frame.Navigate(typeof(PacijentMeni)); 
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message);
                dialog.ShowAsync();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
    }
}
