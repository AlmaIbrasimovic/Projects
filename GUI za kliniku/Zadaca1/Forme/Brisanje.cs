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
    public partial class Brisanje : Form
    {
        public Brisanje()
        {
            InitializeComponent();
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                string podatak = VARIABLE._JMBG + " " + VARIABLE._Ime + " " + VARIABLE._Prezime;
                comboBox1.Items.Add(podatak);
            }
            comboBox1.Text = "--Odaberite--";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (globalnaKlasa.klinika17270.ListaPacijenata.Count == 0)
                {
                   errorProvider1.SetError(groupBox1, "Greška!");
                    throw new Exception("Nema registrovanih pacijenata!");
                }
                if (radioButton1.Checked)
                {
                    globalnaKlasa.klinika17270.ListaPacijenata.Clear();
                    MessageBox.Show("Pacijenti uspješno obrisani.", "Informacija", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                else if (radioButton2.Checked)
                {
                    string novi = comboBox1.SelectedItem.ToString();
                    novi = novi.Substring(0, 13);
                    globalnaKlasa.klinika17270.izbrisiPacijenta(novi);
                    globalnaKlasa.klinika17270.izbrisiKarton(novi);
                    globalnaKlasa.registrovaniPacijenti.Remove(novi);
                    MessageBox.Show("Pacijent uspješno obrisan.", "Informacija", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    comboBox1.Items.Clear();
                    foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
                    {
                        string podatak = VARIABLE._JMBG + " " + VARIABLE._Ime + " " + VARIABLE._Prezime;
                        comboBox1.Items.Add(podatak);
                    }
                    comboBox1.Text = "--Odaberite--";
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = true;
            comboBox1.Visible = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            label1.Visible = false;
            comboBox1.Visible = false;
        }
    }
}
