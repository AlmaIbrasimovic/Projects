using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string lozinkaDoktora = generesiMD5("doktor");
        private string userNameDoktora = "doktor";
        private string lozinkaOstalih = generesiMD5("ostali");
        private string userNameOstalih = "ostali";
        private string lozinkaPacijenta = generesiMD5("pacijent");
        private string userNamePacijenta = "pacijent";
        private Doktor doktor;
        public MainPage()
        {
            this.InitializeComponent();
            doktor = new Doktor();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (userName.Text.Equals(userNameDoktora) && generesiMD5(lozinka.Password.ToString()) == lozinkaDoktora)
            {
             
                Frame.Navigate(typeof(Doktor));
            }
            else if (userName.Text.Equals(userNameOstalih) && generesiMD5(lozinka.Password.ToString()) == lozinkaOstalih)
            {
                Frame.Navigate(typeof(Ostali));
            }
            else if (userName.Text.Equals(userNamePacijenta) && generesiMD5(lozinka.Password.ToString()) == lozinkaPacijenta)
            {
                Frame.Navigate(typeof(Pacijent));
            }
            else greska.Text = "Pogresni pristupni podaci!";
        }
        public static string generesiMD5(string password)
        {
            MD5 kod = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(password);
            byte[] hash = kod.ComputeHash(inputBytes);
            StringBuilder kodirano = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                kodirano.Append(hash[i].ToString("X2"));
            }
            return kodirano.ToString();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }
    }
}
