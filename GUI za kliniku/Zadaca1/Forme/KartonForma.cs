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
    public partial class KartonForma : Form
    {
        public KartonForma()
        {
            InitializeComponent();
            comboBox1.Text = "--Odaberite--";
            foreach (var VARIABLE in globalnaKlasa.registrovaniPacijenti)
            {
                string temp = VARIABLE.Key;
                temp += " " + VARIABLE.Value.Item1;
                temp += " " + VARIABLE.Value.Item2;
                comboBox1.Items.Add(temp);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
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
               toolStripLabel1.Text = string.Empty;
               if (comboBox1.SelectedIndex < 0)
                {
                    errorProvider1.SetError(comboBox1, "Greška!");
                    throw new Exception("Niste odabrali pacijenta!");
                }
                string jmbg = comboBox1.SelectedItem.ToString();
                jmbg = jmbg.Substring(0, 13);
                globalnaKlasa.klinika17270.listaJMBGZaKartone(jmbg);
                MessageBox.Show("Karton uspješno kreiran!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ocistiPodatke();
            }
            catch (Exception ex)
            {
                toolStripLabel1.Text = ex.Message;
            }
        }

        private void ocistiPodatke()
        {
            errorProvider1.SetError(comboBox1, "");
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "--Odaberite--";
        }
    }
}
