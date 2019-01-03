using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using Zadaca1.Forme;

namespace Zadaca1
{
    public partial class DoktorForma : Form
    {   
        List<Pregled> pregledi = new List<Pregled>();
        SviPacijenti mdiChildForm = new SviPacijenti();
        MdiClient klijent;
        public DoktorForma()
        {
            InitializeComponent();
            klijent = Controls.OfType<MdiClient>().First();
            
            klijent.GotFocus += (s, e) => {
                if (!MdiChildren.Any(x => x.Visible)) klijent.SendToBack();
            };
            comboBox1.Text = "--Odaberite--";
            comboBox1.Items.Add("Ortopedska");
            comboBox1.Items.Add("Kardiološka");
            comboBox1.Items.Add("Dermatološka");
            comboBox1.Items.Add("Internistička");
            comboBox1.Items.Add("Otorinolaringološka");
            comboBox1.Items.Add("Oftamološka");
            comboBox1.Items.Add("Laboratorija");
            comboBox1.Items.Add("Stomatološka");

            comboBox2.Text = "--Odaberite--";
            comboBox2.Items.Add("Ortopedski");
            comboBox2.Items.Add("Kardioloski");
            comboBox2.Items.Add("Dermatoloski");
            comboBox2.Items.Add("Internisticki");
            comboBox2.Items.Add("Otorinolaringoloski");
            comboBox2.Items.Add("Oftamoloski");
            comboBox2.Items.Add("Laboratorijski");
            comboBox2.Items.Add("Stomatoloski");

            foreach (var VARIABLE in globalnaKlasa.registrovaniPacijenti)
            {
                string temp = VARIABLE.Key;
                temp += " " + VARIABLE.Value.Item1;
                temp += " " + VARIABLE.Value.Item2;
                comboBox3.Items.Add(temp);
                comboBox4.Items.Add(temp);
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        private void PrikaziFormu(Form childForm)
        {
            klijent.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DoktorForma_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            mdiChildForm.MdiParent = this;
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

        //NE RADI AŽURIRANJE TERAPIJA- radi popravilaa
        private void OK_Click(object sender, EventArgs e)
        {
            try
            {
                if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                {
                    throw new  Exception("Nije registrovan niti jedan pacijent. Ne može se zakazati pregled!");
                }
                bool imaKreiran = false;
                string novi = comboBox4.SelectedItem.ToString();
                novi = novi.Substring(0, 13);
                if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                if (!imaKreiran)
                {
                    errorProvider1.SetError(comboBox4, "Greška!");
                    throw new Exception("Nije kreiran karton za tog pacijenta! Kreirajte");
                } 
                if (comboBox2.SelectedIndex < 0)
                {
                    errorProvider1.SetError(comboBox2, "Odaberite tip pregleda!");
                    throw new Exception("Nepotpuni podaci!");
                }
                if (textBox1.TextLength == 0)
                {
                    errorProvider1.SetError(textBox1, "Unesite cijenu pregleda!");
                    throw new Exception("Nepotpuni podaci!");
                }
                if (comboBox2.SelectedIndex >= 0)
                {
                    errorProvider1.SetError(comboBox2, "");
                    toolStripStatusLabel1.Text = String.Empty;
                }
                toolStripStatusLabel1.Text = "";
             
                Pregled pregled = new Pregled(comboBox2.SelectedItem.ToString(), dateTimePicker1.Value, novi, Convert.ToDouble(textBox1.Text));
                pregledi.Add(pregled);
                globalnaKlasa.klinika17270.registrujNoviPregled(pregled);
             //   globalnaKlasa.klinika17270.ListaPregleda.Add(pregled);
                MessageBox.Show("Pregled uspješno zakazan.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comboBox2.SelectedIndex = -1;
                ocistiPodatke();
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (globalnaKlasa.registrovaniPacijenti.Count == 0)
                {
                    throw new Exception("Nije registrovan niti jedan pacijent. Ne mogu se ažurirati terapije!");
                }
                bool imaKreiran = false;
                string novi = comboBox3.SelectedItem.ToString();
                novi = novi.Substring(0, 13);
                if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                if (!imaKreiran)
                {
                    errorProvider1.SetError(comboBox3, "Greška!");
                    throw new Exception("Ne postoji kreiran karton za tog pacijenta!");
                }
               
                if (textBox4.TextLength == 0)
                {
                    errorProvider2.SetError(textBox4, "Niste unijeli terapije!");
                    throw new Exception("Nepotpuni podaci");
                }
                if (textBox4.TextLength != 0)
                {
                    errorProvider2.SetError(textBox4, "");
                    toolStripStatusLabel2.Text = string.Empty;
                }
                List<string> terapije = new List<string>();
                string[] linije = textBox4.Text.Split('\n');
                foreach (var VARIABLE in linije)
                {
                    terapije.Add(VARIABLE);
                }
                
                globalnaKlasa.klinika17270.azurirajTerapije(terapije, novi);
                MessageBox.Show("Terapije uspješno ažurirane.", "Informacija", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
                textBox4.Text = String.Empty;
            }
            catch (Exception ex)
            {
                toolStripStatusLabel2.Text = ex.Message;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_Click(object sender, MouseEventArgs e)
        {
        }

        private void izlazToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void izlistajSvePacijenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SviPacijenti nov = new SviPacijenti {MdiParent = this};
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Info nov = new Info { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void izlistajSveDoktoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Doktori1 nov = new Doktori1 { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }
      
        private void odjavaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 objekt = new Form1();
            objekt.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox2.SelectedIndex >= 0) errorProvider1.SetError(comboBox2, "");
            toolStripStatusLabel1.Text = string.Empty;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength != 0)
            {
                errorProvider2.SetError(textBox4, "");
                toolStripStatusLabel2.Text = string.Empty;
            }
        }

        private void ocistiPodatke()
        {
            comboBox4.Text = "--Odaberite--";
            comboBox2.Text = "--Odaberite--";
            textBox1.Text = String.Empty;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0)
            {
                string orto = Convert.ToString(globalnaKlasa.orto);
                if (comboBox1.SelectedItem.Equals("Ortopedska"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(orto);
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Kardiološka"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.kard));
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Dermatološka"))
                {
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.derma));
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Internistička"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.inter));
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Otorinolaringološka"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.otoro));
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Oftamološka"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.ofta));
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Laboratorija"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.lab));
                    richTextBox1.AppendText(" pacijenata.");
                }
                if (comboBox1.SelectedItem.Equals("Stomatološka"))
                {
                    richTextBox1.Clear();
                    richTextBox1.AppendText("Trenutno čeka ");
                    richTextBox1.AppendText(Convert.ToString(globalnaKlasa.stoma));
                    richTextBox1.AppendText(" pacijenata.");
                }

            }
        }

        private void analizaSadržajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Analiza nov = new Analiza { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }
        private void comboBox3_Validating(object sender, CancelEventArgs e)
        {/*
            if (comboBox3.SelectedIndex > 0)
            {
                bool imaKreiran = false;
                string novi = comboBox3.SelectedItem.ToString();
                novi = novi.Substring(0, 13);
                if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                if (!imaKreiran)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(comboBox3, "Greška!");
                    toolStripStatusLabel2.Text = ("Nije kreiran karton za tog pacijenta!");
                }
            }
            */
        }

        private void comboBox3_Validated(object sender, EventArgs e)
        {/*
            errorProvider1.SetError(comboBox3, "");
            toolStripStatusLabel2.Text = String.Empty;
            */
        }

        private void comboBox4_Validating(object sender, CancelEventArgs e)
        {
            /*if (comboBox4.SelectedIndex > 0)
            {
                bool imaKreiran = false;
                string novi = comboBox4.SelectedItem.ToString();
                novi = novi.Substring(0, 13);
                if (globalnaKlasa.klinika17270.jmbgListaKartona.Contains(novi)) imaKreiran = true;
                if (!imaKreiran)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(comboBox4, "Greška!");
                    toolStripStatusLabel2.Text = ("Nije kreiran karton za tog pacijenta!");
                }
            }*/
        }
        private void comboBox4_Validated(object sender, EventArgs e)
        {
           /* errorProvider1.SetError(comboBox4, "");
            toolStripStatusLabel2.Text = String.Empty;*/
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (textBox1.TextLength == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Greška!");
                toolStripStatusLabel1.Text = "Unesite cijenu pregleda!";
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            toolStripStatusLabel1.Text = string.Empty;
        }

        private void izlazToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void odjavaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 objekt = new Form1();
            objekt.Show();
        }
    }
}
