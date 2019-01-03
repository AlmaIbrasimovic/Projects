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
    public partial class PopunjavanjeKartona : Form
    {
        public PopunjavanjeKartona()
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
                if (comboBox1.SelectedIndex < 0  || richTextBox1.TextLength == 0 || richTextBox2.TextLength == 0 || richTextBox3.TextLength == 0 || richTextBox4.TextLength == 0)
                {
                    if (comboBox1.SelectedIndex < 0) errorProvider1.SetError(comboBox1, "Greška!");
                    if (richTextBox1.TextLength == 0) errorProvider1.SetError(richTextBox1, "Greška!");
                    if (richTextBox2.TextLength == 0) errorProvider1.SetError(richTextBox2, "Greška!");
                    if (richTextBox3.TextLength == 0) errorProvider1.SetError(richTextBox3, "Greška!");
                    if (richTextBox4.TextLength == 0) errorProvider1.SetError(richTextBox4, "Greška!");
                    throw new Exception("Nepotpuni podaci");
                }
                List<string> bolesti = new List<string>();
                List<string> alergije = new List<string>();
                List<string> terapije = new List<string>();
                List<string> misljenja = new List<string>();
                bolesti.Clear();
                alergije.Clear();
                terapije.Clear();
                misljenja.Clear();   
                bolesti.AddRange(richTextBox1.Lines);
                alergije.AddRange(richTextBox2.Lines);
                misljenja.AddRange(richTextBox4.Lines);
                terapije.AddRange(richTextBox3.Lines);
                string imePrezime = comboBox1.SelectedItem.ToString();
                int vel = Convert.ToInt32(comboBox1.SelectedItem.ToString().Length - 1);
                imePrezime = imePrezime.Substring(14, vel-13);
                string noviJMBG = comboBox1.SelectedItem.ToString();
                noviJMBG = noviJMBG.Substring(0, 13);
                Karton karton = new Karton(imePrezime, noviJMBG,dateTimePicker1.Value, bolesti, alergije, misljenja, terapije);
                globalnaKlasa.klinika17270.kreirajKarton(karton);
                MessageBox.Show("Karton uspješno popunjen!", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ocistiPodatke();
            }
            catch (Exception ex)
            {
                toolStripLabel1.Text = ex.Message;
            }
        }
     
        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (globalnaKlasa.registrovaniPacijenti.Count != 0)
            {
                bool imaKreiran = false;
                string novi = comboBox1.SelectedItem.ToString();
                novi = novi.Substring(0, 13);
                if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                if (!imaKreiran)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(comboBox1, "Greška!");
                    toolStripLabel1.Text = ("Nije kreiran karton za tog pacijenta!");
                }
            }
        }

        private void ocistiPodatke()
        {
            comboBox1.SelectedIndex = -1;
            comboBox1.Text = "--Odaberite--";
            richTextBox1.Clear();
            richTextBox1.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            richTextBox4.Clear();
            dateTimePicker1.Value = DateTime.Today;
        }
        private void comboBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1,"");
            toolStripLabel1.Text = String.Empty;
        }

        private void richTextBox1_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox1.TextLength == 0)
            {
                e.Cancel = true;
                toolStripLabel1.Text = "Greška!";
                errorProvider1.SetError(richTextBox1, "Popunite ovo polje!"); 
            }
        }

        private void richTextBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(richTextBox1,"");
            toolStripLabel1.Text = string.Empty;
        }

        private void richTextBox2_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox2.TextLength == 0)
            {
                e.Cancel = true;
                toolStripLabel1.Text = "Greška!";
                errorProvider1.SetError(richTextBox2, "Popunite ovo polje!");
            }
        }

        private void richTextBox2_Validated(object sender, EventArgs e)
        {
            toolStripLabel1.Text = String.Empty;
            errorProvider1.SetError(richTextBox2, "");          
        }

        private void richTextBox3_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox3.TextLength == 0)
            {
                e.Cancel = true;
                toolStripLabel1.Text = "Greška!";
                errorProvider1.SetError(richTextBox3, "Popunite ovo polje!");
            }
        }

        private void richTextBox3_Validated(object sender, EventArgs e)
        {
              toolStripLabel1.Text = String.Empty;
              errorProvider1.SetError(richTextBox3, "");
        }

        private void richTextBox4_Validated(object sender, EventArgs e)
        {
              toolStripLabel1.Text = String.Empty;
              errorProvider1.SetError(richTextBox4, "");
        }

        private void richTextBox4_Validating(object sender, CancelEventArgs e)
        {
            if (richTextBox4.TextLength == 0)
            {
                e.Cancel = true;
                toolStripLabel1.Text = "Greška!";
                errorProvider1.SetError(richTextBox4, "Popunite ovo polje!");
            }
        }
    }
}
