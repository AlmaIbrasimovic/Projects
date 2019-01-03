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
    public partial class Racun : Form
    {
        public Racun()
        {
            InitializeComponent();
            foreach (var VARIABLE in globalnaKlasa.registrovaniPacijenti)
            {
                string temp = VARIABLE.Key;
                temp += " " + VARIABLE.Value.Item1;
                temp += " " + VARIABLE.Value.Item2;
                comboBox1.Items.Add(temp);
            }
            comboBox1.Text = "--Odaberite--";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ocistiPodatke()
        {
            comboBox1.Text = "--Odaberite--";
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                {
                    errorProvider1.SetError(comboBox1, "Greška!");
                    throw new Exception("Nema registrovanih pacijenata!");
                }
                string novi = comboBox1.SelectedItem.ToString();
                int tipPlacanja = 0;
                if (radioButton1.Checked) tipPlacanja = 1;
                else tipPlacanja = 2;
                novi = novi.Substring(0, 13);
                string cijena = string.Empty;
                bool postoji = false;
                double racun = 0D;
                foreach (var pregled in globalnaKlasa.klinika17270.ListaPregleda)
                {
                    if (pregled.jmbg.Equals(novi))
                    {
                        postoji = true;
                        racun = globalnaKlasa.klinika17270.obracunajCijenePregleda(novi, tipPlacanja);
                    }
                }
                if (!postoji) racun = 0;
                cijena = "Ukupan iznos racuna je " + racun.ToString() + " KM.";
                MessageBox.Show(cijena, "Račun", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ocistiPodatke();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }
    }
}
