using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca1.Forme
{
    public partial class Analiza : Form
    {
        public Analiza()
        {
            InitializeComponent();
            richTextBox2.AppendText(
                "Crvena-- Kardiološki\nPlava -- Dermatoloski\nBordo -- Internistički\nŽuta -- Otorinolaringološki\nZelena -- Oftamološki\nLjubičasta -- Laboratorijski\nTirkizna -- Stomatološki");
        }
        private void Analiza_Load(object sender, EventArgs e)
        {
         
        }
        private void kreiraj()
        {
            groupBox3.Visible = true;
            int[] vrijednostiZaGrafik = new int[8];
            for (int i = 0; i < vrijednostiZaGrafik.Length; i++) vrijednostiZaGrafik[i] = 0;
            for (int i = 0; i<globalnaKlasa.klinika17270.ListaPregleda.Count; i++)
            {
                if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Ortopedski")) vrijednostiZaGrafik[0]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Kardioloski")) vrijednostiZaGrafik[1]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Dermatoloski")) vrijednostiZaGrafik[2]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Internisticki")) vrijednostiZaGrafik[3]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Otorinolaringoloski")) vrijednostiZaGrafik[4]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Oftamoloski")) vrijednostiZaGrafik[5]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Labaratorijski")) vrijednostiZaGrafik[6]++;
                else if (globalnaKlasa.klinika17270.ListaPregleda[i]._tipPregleda.Equals("Stomatoloski")) vrijednostiZaGrafik[7]++;
            }
            double suma = 0D;
            for (int i = 0; i< vrijednostiZaGrafik.Length; i++)
            {
                vrijednostiZaGrafik[i] = Int32.Parse(vrijednostiZaGrafik[i].ToString());
                suma += vrijednostiZaGrafik[i];
            }

            Color[] boje = { Color.Red, Color.Blue, Color.Maroon, Color.Yellow, Color.Green, Color.Indigo, Color.DarkMagenta, Color.Cyan, };
            Rectangle rect = new Rectangle(30, 10, 130, 130);

            Graphics graphics = pictureBox1.CreateGraphics();
            graphics.Clear(pictureBox1.BackColor);

            float vrijednost = 0.0f;
            float novaSuma = 0.0f;

            for (int i = 0; i < vrijednostiZaGrafik.Length; i++)
            {
                vrijednost = (float) ((vrijednostiZaGrafik[i] / suma) * 360);
                Brush brush = new SolidBrush(boje[i]);
                graphics.FillPie(brush, rect, novaSuma, novaSuma);
                novaSuma += vrijednost;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            pictureBox1.Visible = false;
            richTextBox2.Visible = false;
            groupBox2.Visible = true;
            richTextBox1.AppendText("Najplaćeniji doktor je " + globalnaKlasa.klinika17270.najplacenijiDoka());
       
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            pictureBox1.Visible = true;
            richTextBox2.Visible = true;
            
            groupBox2.Visible = false;
            richTextBox1.Clear();
            kreiraj();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kreiraj();
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
