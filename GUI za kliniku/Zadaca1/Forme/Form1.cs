using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace Zadaca1
{
    public partial class Form1 : Form
    {
        Thread th;
        private string lozinkaDoktora = generesiMD5("doktor");
        private string userNameDoktora = "doktor";
        private string lozinkaOstalih = generesiMD5("ostali");
        private string userNameOstalih = "ostali";
        private string lozinkaPacijenta = generesiMD5("pacijent");
        private string userNamePacijenta = "pacijent";

        public Form1()
        {
            InitializeComponent();
            Doktori d1 = new Doktori("Veljko", "Kunić", 1200, "Kardiolog", "doktor", generesiMD5("doktor"));
            Doktori d2 = new Doktori("Ante", "Guzina", 1500, "Oftamolog", "doktor", generesiMD5("doktor"));
            Doktori d3 = new Doktori("Toni", "Grgeč", 1000, "Internista", "doktor", generesiMD5("doktor"));
            Doktori d4 = new Doktori("Franjo", "Slaviček", 800, "Stomatolog", "doktor", generesiMD5("doktor"));
            Doktori d5 = new Doktori("Lili", "Štriga", 1100, "Dermatolog", "doktor", generesiMD5("doktor"));
            Doktori d6 = new Doktori("Florijan", "Gavran", 950, "Otorinolaringolog", "doktor", generesiMD5("doktor"));
            Doktori d7 = new Doktori("Sestra", "Helga", 750, "Laborant", "doktor", generesiMD5("doktor"));
            Doktori d8 = new Doktori("Bogo", "Moljka", 1150, "Ortoped", "doktor", generesiMD5("doktor"));
            globalnaKlasa.klinika17270.registrujDoktora(d1); globalnaKlasa.klinika17270.registrujDoktora(d2);
            globalnaKlasa.klinika17270.registrujDoktora(d3); globalnaKlasa.klinika17270.registrujDoktora(d4);
            globalnaKlasa.klinika17270.registrujDoktora(d5); globalnaKlasa.klinika17270.registrujDoktora(d6);
            globalnaKlasa.klinika17270.registrujDoktora(d7); globalnaKlasa.klinika17270.registrujDoktora(d8);
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
        private void IzlazButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (DoktorRadio.Checked)
            {
                if (ImeText.Text == userNameDoktora && generesiMD5(LozinkaText.Text) == lozinkaDoktora)
                {
                    this.Close();
                    th = new Thread(otvoriNovuFormu);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
               }
            }
            else if (OstaloRadio.Checked)
            {
                if (ImeText.Text == userNameOstalih && generesiMD5(LozinkaText.Text) == lozinkaOstalih)
                {
                    this.Close();
                    th = new Thread(otvoriNovu);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
                }
            }
            else if (PacijentRadio.Checked)
            {
               
               if (ImeText.Text == userNamePacijenta && generesiMD5(LozinkaText.Text) == lozinkaPacijenta)
                {
                    this.Close();
                    th = new Thread(otvoriNovuPacijent);
                    th.SetApartmentState(ApartmentState.STA);
                    th.Start();
               }
            }
        }
        private void otvoriNovuPacijent(object ob)
        {
            Application.Run(new LogInPacijenta());
        }
        private void otvoriNovuFormu(object ob)
        {
            Application.Run(new DoktorForma());     
        }
        private void otvoriNovu(object ob)
        {
            Application.Run(new OstaliForma());
        }

        private void Form1_Load(object sender, EventArgs e)
        {          
            PreminuliPacijenti pac1 = new PreminuliPacijenti("Kurt", "Cobain", new DateTime(1994, 4, 5),new DateTime(1967, 2, 20), "Samoubistvo", "Muško");
            PreminuliPacijenti pac2 = new PreminuliPacijenti("Emina", "Ćatić", new DateTime(2017,12,20), new DateTime(1997, 2, 14), "Popila strihnin", "Žensko");
            PreminuliPacijenti pac3 = new PreminuliPacijenti("Chester", "Bennington", new DateTime(2017, 7, 20), new DateTime(1976, 3, 20), "Samoubistvo", "Muško");
            PreminuliPacijenti pac4 = new PreminuliPacijenti("Kenan", "Bajrić", new DateTime(2015, 8, 16), new DateTime(1991, 5, 20), "Saobraćajna nesreća", "Muško");
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac1);
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac2);
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac3);
            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac4);
        }
        private void ImeText_Validating(object sender, CancelEventArgs e)
        {
            if (DoktorRadio.Checked)
            {
                if (ImeText.Text != userNameDoktora)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(ImeText, "Nije dobro ime");
                    toolStripStatusLabel1.Text = "Nije dobro ime";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
            else if (OstaloRadio.Checked)
            {
                if (ImeText.Text != userNameOstalih)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(ImeText, "Nije dobro ime");
                    toolStripStatusLabel1.Text = "Nije dobro ime";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
            else
            {
                if (ImeText.Text != userNamePacijenta)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(ImeText, "Nije dobro ime");
                    toolStripStatusLabel1.Text = "Nije dobro ime";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }
        private void LozinkaText_Validating(object sender, CancelEventArgs e)
        {
            if (DoktorRadio.Checked)
            {
                if (generesiMD5(LozinkaText.Text) != lozinkaDoktora)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(LozinkaText, "Nije dobra lozinka");
                    toolStripStatusLabel1.Text = "Nije dobra lozinka";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
            else if (OstaloRadio.Checked)
            {
                if (generesiMD5(LozinkaText.Text) != lozinkaOstalih)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(LozinkaText, "Nije dobra lozinka");
                    toolStripStatusLabel1.Text = "Nije dobra lozinka";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
            else
            {
                if (generesiMD5(LozinkaText.Text) != lozinkaPacijenta)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(LozinkaText, "Nije dobra lozinka");
                    toolStripStatusLabel1.Text = "Nije dobra lozinka";
                    toolStripStatusLabel1.ForeColor = Color.Red;
                }
            }
        }
        
        private void ImeText_Validated(object sender, EventArgs e)
        {  
            errorProvider1.SetError(ImeText, "");
            toolStripStatusLabel1.Text = String.Empty;
        }

        private void LozinkaText_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(LozinkaText,"");
            toolStripStatusLabel1.Text = string.Empty;
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics GI; 
            GI = this.CreateGraphics();
            Pen crvena = new Pen(Color.DarkRed, 5); 
            Pen bijela = new Pen(Color.White, 5);
            GI.DrawLine(crvena, 265, 100, 275, 100);
            GI.DrawLine(crvena, 290, 100, 300, 100);
            GI.DrawLine(crvena, 260, 105, 280, 105);
            GI.DrawLine(crvena, 285, 105, 305, 105);
            GI.DrawLine(crvena, 255, 110, 310, 110);
            GI.DrawLine(crvena, 255, 115, 280, 115);
            GI.DrawLine(bijela, 280, 115, 285, 115);
            GI.DrawLine(crvena, 285, 115, 310, 115);
            GI.DrawLine(crvena, 260, 120, 275, 120);
            GI.DrawLine(bijela, 275, 120, 290, 120);
            GI.DrawLine(crvena, 290, 120, 305, 120);
            GI.DrawLine(crvena, 265, 125, 280, 125);
            GI.DrawLine(bijela, 280, 125, 285, 125);
            GI.DrawLine(crvena, 285, 125, 300, 125);
            GI.DrawLine(crvena, 270, 130, 295, 130);
            GI.DrawLine(crvena, 275, 135, 290, 135);
            GI.DrawLine(crvena, 280, 140, 285, 140);
            using (Font font1 = new Font("Times New Roman", 16, FontStyle.Bold, GraphicsUnit.Point))
            {
                PointF pointF1 = new PointF(252,150);
                e.Graphics.DrawString("NMK", font1, Brushes.DarkRed, pointF1);
            }
        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                ImeText_Validating(sender, new CancelEventArgs());
                LozinkaText_Validating(sender, new CancelEventArgs());
                OKButton_Click(sender,e);
            }
        }
    }
}
