using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca1
{
    public partial class PrikazKartona : Form
    {
        public PrikazKartona()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void PrikazKartona_Load(object sender, EventArgs e)
        {
            
            string ime = String.Empty;
            string prezime = string.Empty;
            string spol = String.Empty;
            string bracno = String.Empty;
            DateTime datumRodjenja = DateTime.Now;
            DateTime datumPregleda = DateTime.Now;
            Image slika = null;
            List<string> bolesti = new List<string>();
            List<string> terapije = new List<string>();
            List<string> misljenja = new List<string>();
            List<string> alergije = new List<string>();
            label7.Text = "Karton pacijenta ";
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                if (VARIABLE._JMBG == globalnaKlasa.jmbgZaDoktora)
                {
                    
                    ime = VARIABLE._Ime;
                    prezime = VARIABLE._Prezime;
                    datumRodjenja = VARIABLE._datumRodjenja;
                    spol = VARIABLE._Spol;
                    bracno = VARIABLE.Brak;
                    slika = VARIABLE.Slika;
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
            textBox1.Text = ime;
            textBox2.Text = prezime;
            dateTimePicker1.Value = datumRodjenja;
            textBox4.Text = spol;
            textBox5.Text = globalnaKlasa.jmbgZaDoktora;
            textBox6.Text = bracno;
            dateTimePicker2.Value = datumPregleda;
            pictureBox1.Image = slika;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            foreach (var VARIABLE in alergije)
            {
                richTextBox1.AppendText(VARIABLE);
            }
            foreach (var VARIABLE in bolesti)
            {
                richTextBox2.AppendText(VARIABLE);
            }
            foreach (var VARIABLE in terapije)
            {
                richTextBox3.AppendText(VARIABLE);
            }
            foreach (var VARIABLE in misljenja)
            {
                richTextBox4.AppendText(VARIABLE);
            }
            label7.Text += ime + " " + prezime;
        }
    }
}
