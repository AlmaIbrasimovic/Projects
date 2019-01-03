using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
   // [Serializable]
    public abstract class Uposlenici : IPrint
    {
        private int zagarantovanaPlata = 1000;
        private string userName;
        private string password;
        List<string> listaLozinki = new List<string>();
        List<string> listaUserName = new List<string>();
        public Uposlenici() {}

        public Uposlenici(int zagarantovanaPlata, string ime, string pass)
        {
            this.zagarantovanaPlata = zagarantovanaPlata;
            UserName = ime;
            Passworda = pass;
        }
        public int ZagarantovanaPlata
        {
            get { return zagarantovanaPlata; }
            set { zagarantovanaPlata = value; }
        }
        public string UserName { get => userName; set => userName = value; }
        public string Passworda {
            get => password;
            set => password=(value);
        }
        public List<string> ListaUserName { get => listaUserName; set => listaUserName = value; }

        public string generesiMD5(string password)
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
        abstract public string ispisiString();
    }
}
