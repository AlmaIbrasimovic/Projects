using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaca1
{
  //  [Serializable]
    public class globalnaKlasa
    {
        public static int orto = 0;
        public static int kard = 0;
        public static int derma = 0;
        public static int inter = 0;
        public static int otoro = 0;
        public static int ofta = 0;
        public static int lab = 0;
        public static int stoma = 0;
        public static int ortoDoktori = 0;
        public static int kardDoktori = 0;
        public static int dermaDoktori = 0;
        public static int interDoktori = 0;
        public static int otoroDoktori = 0;
        public static int oftaDoktori = 0;
        public static int labDoktori = 0;
        public static int stomaDoktori = 0;
        public static Klinika klinika17270 = new Klinika();
        public static Dictionary<string,string> listaZaKartone = new Dictionary<string, string>();
        public static string jmbgZaPacijenta = string.Empty;
        public static string jmbgZaDoktora = String.Empty;
        public static List<Doktori> doce = new List<Doktori>();
        public static Dictionary<string, Tuple<string, string>> registrovaniPacijenti = new Dictionary<string, Tuple<string, string>>();
        public static bool validacijaJMBG(string jmbg)
        {
            if (jmbg.Length != 13 ) return false;
            return true;
        }

       /* public static void kreirajIzuzetak(Exception ex,string tip,DateTime vrijeme)
        {
            var putanja = string.Format("{0}\\Logovi.txt", AppDomain.CurrentDomain.BaseDirectory);
            if (!File.Exists(putanja))
            {
                FileStream fajl = new FileStream(putanja.ToString(),FileMode.Create);
                fajl.Close();
            }
            FileStream novi = new FileStream(putanja.ToString(),FileMode.Append,FileAccess.Write);
            TextWriter pisac = new StreamWriter(novi);
            pisac.WriteLine("{0},{1},{2}", tip, vrijeme, ex.Message);
            pisac.Flush();
            novi.Close();
        }*/
    }
}
