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
    public partial class Registracija : Form
    {
        //Hitni childForma = new Hitni();
        List<string> listaPrvePomoci = new List<string>();
        MdiClient klijent = new MdiClient();
        public Registracija()
        {
            InitializeComponent();
            comboBox1.Text = "--Odaberite--";
            comboBox2.Text = "--Odaberite--";
            comboBox3.Text = "--Odaberite--";
            /* klijent = Controls.OfType<MdiClient>().First();
             klijent.GotFocus += (s, e) => {
                 if (!MdiChildren.Any(x => x.Visible)) klijent.SendToBack();
             };*/
            comboBox1.Items.Add("Hitni slučaj");
            comboBox1.Items.Add("Normalni slučaj");
            comboBox2.Items.Add("Muško");
            comboBox2.Items.Add("Žensko");
            comboBox3.Items.Add("Oženjen/udata");
            comboBox3.Items.Add("Razveden/a");
            comboBox3.Items.Add("Udovac/udovica");
            comboBox3.Items.Add("Slobodan/slobodna");
            setovanjeNaFalse();

        }
       
        private void Registracija_Load(object sender, EventArgs e)
        {
          /*  IsMdiContainer = true;
            childForma.MdiParent = this;*/
        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (brojMjeseciIzmedu(dateTimePicker5.Value) > 6) errorProvider1.SetError(pictureBox1, "Slika starija od 6 mjeseci. Učitajte novu!");
                if (comboBox1.SelectedIndex >= 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && dateTimePicker1.Value != null && comboBox2.SelectedIndex >= 0 && comboBox3.SelectedIndex >= 0 && dateTimePicker2.Value != null && pictureBox1.Image != null && comboBox1.SelectedItem.Equals("Normalni slučaj") && brojMjeseciIzmedu(dateTimePicker5.Value) < 6) goto ok;
                if (comboBox1.SelectedIndex >= 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && dateTimePicker1.Value != null && comboBox2.SelectedIndex >= 0 && comboBox3.SelectedIndex >= 0 && dateTimePicker2.Value != null && pictureBox1.Image != null && comboBox1.SelectedItem.Equals("Hitni slučaj") && brojMjeseciIzmedu(dateTimePicker5.Value) < 6 && richTextBox1.TextLength != 0 && radioButton2.Checked ) goto ok;
                if (comboBox1.SelectedIndex >= 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && dateTimePicker1.Value != null && comboBox2.SelectedIndex >= 0 && comboBox3.SelectedIndex >= 0 && dateTimePicker2.Value != null && pictureBox1.Image != null && comboBox1.SelectedItem.Equals("Hitni slučaj") && brojMjeseciIzmedu(dateTimePicker5.Value) < 6 && richTextBox1.TextLength != 0 && radioButton1.Checked && dateTimePicker3.Value != null && textBox4.TextLength != 0 && radioButton5.Checked) goto ok;
                if (comboBox1.SelectedIndex >= 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && textBox3.TextLength != 0 && dateTimePicker1.Value != null && comboBox2.SelectedIndex >= 0 && comboBox3.SelectedIndex >= 0 && dateTimePicker2.Value != null && pictureBox1.Image != null && comboBox1.SelectedItem.Equals("Hitni slučaj") && brojMjeseciIzmedu(dateTimePicker5.Value) < 6 && richTextBox1.TextLength != 0 && radioButton1.Checked && dateTimePicker3.Value != null && textBox4.TextLength != 0 && radioButton6.Checked && dateTimePicker4.Value != null) goto ok;
                if (richTextBox1.TextLength != 0 && textBox3.TextLength != 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && comboBox1.SelectedIndex >= 0 && comboBox2.SelectedIndex >= 0 && comboBox3.SelectedIndex >= 0 && pictureBox1.Image != null)
                {
                    if (textBox3.TextLength != 0) errorProvider1.SetError(textBox3, "");
                    if (textBox1.TextLength != 0) errorProvider1.SetError(textBox1, "");
                    if (textBox2.TextLength != 0) errorProvider1.SetError(textBox2, "");
                    if (pictureBox1.Image != null) errorProvider1.SetError(pictureBox1, "");
                    if (comboBox1.SelectedIndex >= 0) errorProvider1.SetError(comboBox1, "");
                    if (comboBox2.SelectedIndex >= 0) errorProvider1.SetError(comboBox2, "");
                    if (comboBox3.SelectedIndex >= 0) errorProvider1.SetError(comboBox3, "");
                    if (comboBox1.SelectedItem.Equals("Normalni slučaj")) goto ok;
                    if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedItem.Equals("Hitni slučaj"))
                    {
                        if (richTextBox1.TextLength != 0) errorProvider1.SetError(richTextBox1, "");
                        if (radioButton1.Checked || radioButton2.Checked)
                            errorProvider1.SetError(groupBox1, "");
                        if (radioButton1.Checked)
                        {
                            if (textBox4.TextLength != 0) errorProvider1.SetError(textBox4, "");
                            if (radioButton5.Checked || radioButton6.Checked)
                                errorProvider1.SetError(groupBox2, "");
                        }
                    }
                }
                if (richTextBox1.TextLength == 0 || textBox3.TextLength == 0  || textBox1.TextLength == 0 || textBox2.TextLength == 0 || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 || comboBox3.SelectedIndex < 0 || pictureBox1.Image == null || !radioButton2.Checked || !radioButton5.Checked || !radioButton6.Checked || !radioButton1.Checked)
                {
                    
                    if (textBox3.TextLength == 0) errorProvider1.SetError(textBox3, "Unesite JMBG pacijenta!");
                    if (textBox1.TextLength == 0) errorProvider1.SetError(textBox1, "Unesite ime pacijenta!");
                    if (textBox2.TextLength == 0) errorProvider1.SetError(textBox2, "Unesite prezime pacijenta!");
                    if (pictureBox1.Image == null) errorProvider1.SetError(pictureBox1, "Odaberite sliku!");
                    if (comboBox1.SelectedIndex < 0) errorProvider1.SetError(comboBox1, "Odaberite tip pacijenta!");
                    if (comboBox2.SelectedIndex < 0) errorProvider1.SetError(comboBox2, "Odaberite spol pacijenta");
                    if (comboBox3.SelectedIndex < 0) errorProvider1.SetError(comboBox3, "Odaberite bračno stanje pacijenta!");
                    if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedItem.Equals("Hitni slučaj"))
                    {
                        if (richTextBox1.TextLength == 0 ) errorProvider1.SetError(richTextBox1, "Opišite prvu pomoć!");
                        if (!(radioButton1.Checked) && !(radioButton2.Checked))
                            errorProvider1.SetError(groupBox1, "Odaberite!");
                        if (radioButton1.Checked)
                        {
                            if (textBox4.TextLength == 0) errorProvider1.SetError(textBox4, "Unesite uzrok smrti!");
                            if (!(radioButton5.Checked) && !(radioButton6.Checked))
                                errorProvider1.SetError(groupBox2, "Odaberite!");
                        } 
                    }   
                   throw new Exception("Nepotpuni podaci!");
                }
               ok:
                toolStripLabel1.Text = string.Empty;
               
                if (comboBox1.SelectedItem.Equals("Normalni slučaj"))
                {
                    NormalniSlucajevi pac = new NormalniSlucajevi(textBox1.Text, textBox2.Text, dateTimePicker1.Value,
                        textBox3.Text, comboBox2.SelectedItem.ToString(), dateTimePicker2.Value,
                        comboBox3.SelectedItem.ToString(), pictureBox1.ImageLocation,pictureBox1.Image);
                    globalnaKlasa.klinika17270.registrujNovogPacijenta(pac);

                  //  globalnaKlasa.klinika17270.ListaPacijenata.Add(pac);
                }
                else if (comboBox1.SelectedItem.Equals("Hitni slučaj"))
                {
                    HitniSlucajevi pac = new HitniSlucajevi(textBox1.Text, textBox2.Text, dateTimePicker1.Value,
                        textBox3.Text, comboBox2.SelectedItem.ToString(), dateTimePicker2.Value,
                        comboBox3.SelectedItem.ToString(),pictureBox1.ImageLocation, pictureBox1.Image);
                    globalnaKlasa.klinika17270.registrujNovogPacijenta(pac);
                   // globalnaKlasa.klinika17270.ListaPacijenata.Add(pac);
                    listaPrvePomoci.Clear();
                    listaPrvePomoci.AddRange(richTextBox1.Lines);
                  
                    if (radioButton1.Checked)
                    {
                        if (radioButton6.Checked)
                        {
                            PreminuliPacijenti pac1 = new PreminuliPacijenti(textBox1.Text, textBox2.Text,
                                dateTimePicker3.Value, dateTimePicker1.Value, textBox4.Text,
                                comboBox2.SelectedItem.ToString(), true, dateTimePicker4.Value);
                            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac1);
                        }
                        else if (radioButton5.Checked)
                        {
                            PreminuliPacijenti pac1 = new PreminuliPacijenti(textBox1.Text, textBox2.Text,
                                dateTimePicker3.Value, dateTimePicker1.Value, textBox4.Text,
                                comboBox2.SelectedItem.ToString());
                            globalnaKlasa.klinika17270.registrujPreminulogPacijenta(pac1);
                        }
                    }
                }
                MessageBox.Show("Pacijent uspješno registrovan.", "Informacija", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Tuple<string,string> podaci = new Tuple<string, string>(textBox1.Text,textBox2.Text);
                globalnaKlasa.registrovaniPacijenti.Add(textBox3.Text,podaci);
                ocistiPodatke();
                setovanjeNaFalse();
            }
            catch (Exception ex)
            {
                toolStripLabel1.Text = ex.Message;
            }

        }
        private void PrikaziFormu(Form childForm)
        {
            klijent.BringToFront();
            childForm.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {         
            if (comboBox1.SelectedIndex >= 0) errorProvider1.SetError(comboBox1, "");
            if (comboBox1.SelectedItem.Equals("Hitni slučaj"))
            {
                label9.Visible = true;
                groupBox1.Visible = true;
                richTextBox1.Visible = true;
                radioButton1.Visible = true;
                radioButton2.Visible = true;
            }
            else if (comboBox1.SelectedItem.Equals("Normalni slučaj")) setovanjeNaFalse();
        }
        private void setovanjeNaFalse()
        {
            label9.Visible = false;
            groupBox1.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            groupBox2.Visible = false;
            label14.Visible = false;
            richTextBox1.Visible = false;
        
            dateTimePicker3.Visible = false;
            dateTimePicker4.Visible = false;
            textBox4.Visible = false;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton6.Checked) errorProvider1.SetError(groupBox2, "");
            label14.Visible = true;
            dateTimePicker4.Visible = true;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
           if (radioButton5.Checked) errorProvider1.SetError(groupBox2, "");
            label14.Visible = false;
            dateTimePicker4.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string lokacijaSlike = String.Empty;
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files (*.jpg)|*.jpg";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    lokacijaSlike = dialog.FileName;
                    pictureBox1.ImageLocation = lokacijaSlike;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Greška!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked) errorProvider1.SetError(groupBox1, "");
            label11.Visible = false;
            label12.Visible = false;
            dateTimePicker3.Visible = false;
            textBox4.Visible = false;
            groupBox2.Visible = false;
            dateTimePicker4.Visible = false;
            label14.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked) errorProvider1.SetError(groupBox1, "");
            label11.Visible = true;
            label12.Visible = true;
            dateTimePicker3.Visible = true;
            textBox4.Visible = true;
            groupBox2.Visible = true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex >= 0) errorProvider1.SetError(comboBox2, "");
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex >= 0) errorProvider1.SetError(comboBox3, "");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null) errorProvider1.SetError(pictureBox1, "");
           
            if (dateTimePicker1.Value != null)
            {
                if (brojMjeseciIzmedu(dateTimePicker5.Value) > 6)
                {
                    errorProvider1.SetError(groupBox1, "Greska!");
                    toolStripLabel1.Text = "Slika starija od 6 mjeseci! Odaberite noviju sliku";
                }
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.Equals("Hitni slučaj"))
            {
                if (richTextBox1.TextLength != 0) errorProvider1.SetError(richTextBox1,"");
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            if (radioButton1.Checked || radioButton2.Checked) errorProvider1.SetError(groupBox1, "");
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (textBox4.TextLength != 0) errorProvider1.SetError(textBox4, "");
        }
        public int brojMjeseciIzmedu(DateTime dat1)
        {
            DateTime dat2 = DateTime.Today;
            int brojMjeseci = 12 * (dat1.Year - dat2.Year) + dat1.Month - dat2.Month;
            return Math.Abs(brojMjeseci);
        }
        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            if (brojMjeseciIzmedu(dateTimePicker5.Value) < 6) errorProvider1.SetError(pictureBox1,"");
        }
        private void pictureBox1_Validating(object sender, CancelEventArgs e)
        {
            /*
            if (pictureBox1.Image == null)
            {
                e.Cancel = true;
                errorProvider1.SetError(groupBox1, "Odaberite sliku!");
                toolStripLabel1.Text = "Odaberite sliku!";
            }
            if (dateTimePicker1.Value != null)
            {
                if (brojMjeseciIzmedu(dateTimePicker5.Value) > 6)
                {
                    e.Cancel = true;
                    errorProvider1.SetError(groupBox1, "Greska!");
                    toolStripLabel1.Text = "Slika starija od 6 mjeseci! Odaberite noviju sliku";
                }
            }*/
        }
        private void ocistiPodatke()
        {
            comboBox1.Text = "--Odaberite--";
            comboBox2.Text = "--Odaberite--";
            comboBox3.Text = "--Odaberite--";
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Clear();
            textBox4.Text = String.Empty;
            pictureBox1.Image = null;
            richTextBox1.Text = string.Empty;
            dateTimePicker1.Value = DateTime.Today;
            
        }
        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (textBox3.Text.Length > 0 && textBox3.Text.Length < 13)
            {
                e.Cancel = true;
                errorProvider2.SetError(textBox3, "Greška!");
                toolStripLabel1.Text = "Dužina JMBG mora biti 13!";
            }
            if (globalnaKlasa.klinika17270.ListaPacijenata.Any(x => x._JMBG.Equals(textBox3.Text)))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Greška!");
                toolStripLabel1.Text = "Već postoji pacijent sa tim JMBG-om!";
            }
            bool jmbg = false;
            if (textBox3.Text.Length == 13) jmbg = ValidacijaJmbg(textBox3.Text);

            if (!jmbg && textBox3.Text.Length == 13)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox3, "Greška!");
                toolStripLabel1.Text = "Pogrešan JMBG!";
            }
        }
        private void textBox3_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox3, ""); errorProvider2.SetError(textBox3, "");
            toolStripLabel1.Text = String.Empty;    
        }
        private void pictureBox1_Validated(object sender, EventArgs e)
        {
        }
        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            bool ima = false;
            for (int i = 0; i < textBox1.TextLength; i++)
            {
                if (textBox1.Text[i] >= '0' && textBox1.Text[i] <= '9') ima = true;
            }
            if (textBox1.TextLength == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Greška!");
                toolStripLabel1.Text = "Niste unijeli ime. Ponovite unos!";
            }
            if (ima)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Greška!");
                toolStripLabel1.Text = "Tip podatka za ime mora biti 'string'. Ponovite unos!";
            }
        }
        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            toolStripLabel1.Text = String.Empty;
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            bool ima = false;
            for (int i = 0; i < textBox2.TextLength; i++)
            {
                if (textBox2.Text[i] >= '0' && textBox2.Text[i] <= '9') ima = true;
            }
            if (textBox2.TextLength == 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Greška!");
                toolStripLabel1.Text = "Niste unijeli prezime. Ponovite unos!";
            }
            if (ima)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox2, "Greška!");
                toolStripLabel1.Text = "Tip podatka za prezime mora biti 'string'. Ponovite unos!";
            }
        }
        private void textBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox2, "");
            toolStripLabel1.Text = String.Empty;
        }

        private bool ValidacijaDatumaRodjenaZaJmbg(string jmbg)
        {
            string dan = dateTimePicker1.Value.Day.ToString();
            int tempDan = Convert.ToInt32(dan);
            if (tempDan <= 9) dan = "0" + dan;
            string mjesec = dateTimePicker1.Value.Month.ToString();
            int tempMjesec = Convert.ToInt32(mjesec);
            if (tempMjesec <= 9) mjesec = "0" + mjesec;
            string godina = dateTimePicker1.Value.Year.ToString();
            godina = godina.Substring(1, 3);
            string skraceni = jmbg.Substring(0, 7);
            string formiraniDatum = dan + mjesec + godina;
            bool jesteOK = true;
            for (int i = 0; i < formiraniDatum.Length; i++)
            {
                if (formiraniDatum[i] != skraceni[i])
                {
                    jesteOK = false;
                    break;
                }
            }
            return jesteOK;
        }
     
        private bool ValidacijaJmbg(string jmbg)
        {
            string spol = comboBox2.SelectedItem.ToString(); // od 000-499 muško, 500-999 žensko
            string kodSpola = String.Empty;
            kodSpola = jmbg.Substring(9, 3);
            int tempKodSpola = Convert.ToInt32(kodSpola);
            bool jelOK = true;
            bool datum = ValidacijaDatumaRodjenaZaJmbg(jmbg);
            if (!datum) return false;
            if (jmbg.Length != 13) return false;
            if (ValidacijaDatumaRodjenaZaJmbg(jmbg))
            {
                if (spol == "Žensko")
                {
                    if (tempKodSpola < 500 || tempKodSpola <= 0)
                        jelOK = false;
                }
                else if (spol == "Muško" && tempKodSpola > 499) jelOK = false; 
             }
            return jelOK;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            if (comboBox1.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox1, "Greška!");
                toolStripLabel1.Text = "Niste odabrali tip!";
            }
        }

        private void comboBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox1, "");
            toolStripLabel1.Text = String.Empty;  
        }

        private void comboBox2_Validating(object sender, CancelEventArgs e)
        {
            greska:
            if (comboBox2.SelectedIndex < 0)
            {
                e.Cancel = true;
                errorProvider1.SetError(comboBox2, "Greška!");
                toolStripLabel1.Text = "Niste odabrali spol!";
            }
        }

        private void comboBox2_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(comboBox2, "");
            toolStripLabel1.Text = String.Empty;
        }

        private void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            if (comboBox2.SelectedIndex < 0)
            {  
                errorProvider1.SetError(comboBox2, "Greška!");
                toolStripLabel1.Text = "Niste odabrali spol!";
            }
        }
    }
}
