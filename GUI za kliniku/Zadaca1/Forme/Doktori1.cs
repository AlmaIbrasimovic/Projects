using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Zadaca1
{
    public partial class Doktori1 : Form
    {
        List<Doktori> doktori = new List<Doktori>();
       
        public Doktori1()
        {
            InitializeComponent();
            foreach (var VARIABLE in doktori)
            {
                richTextBox1.AppendText(VARIABLE.ispisiString());
                richTextBox1.AppendText("\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
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

        private void Doktori1_Load(object sender, EventArgs e)
        {

            Doktori d1 = new Doktori("Veljko", "Kunić", 1200, "Kardiolog", "doktor", generesiMD5("doktor"));
            Doktori d2 = new Doktori("Ante", "Guzina", 1500, "Oftamolog", "doktor", generesiMD5("doktor"));
            Doktori d3 = new Doktori("Toni", "Grgeč", 1000, "Internista", "doktor", generesiMD5("doktor"));
            Doktori d4 = new Doktori("Franjo", "Slaviček", 800, "Stomatolog", "doktor", generesiMD5("doktor"));
            Doktori d5 = new Doktori("Lili", "Štriga", 1100, "Dermatolog", "doktor", generesiMD5("doktor"));
            Doktori d6 = new Doktori("Florijan", "Gavran", 950, "Otorinolaringolog", "doktor", generesiMD5("doktor"));
            Doktori d7 = new Doktori("Sestra", "Helga", 750, "Laborant", "doktor", generesiMD5("doktor"));
            Doktori d8 = new Doktori("Bogo", "Moljka", 1150, "Ortoped", "doktor", generesiMD5("doktor"));
            doktori.Add(d1); doktori.Add(d2); doktori.Add(d3); doktori.Add(d4);
            doktori.Add(d5); doktori.Add(d6); doktori.Add(d7); doktori.Add(d8);
        }
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            foreach (var VARIABLE in doktori)
            {
                richTextBox1.AppendText(VARIABLE.ispisiString());
                richTextBox1.AppendText("\n");
            }
        }
    }
}
