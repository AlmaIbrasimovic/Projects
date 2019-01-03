using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca1
{
    public partial class LogInPacijenta : Form
    {
        Thread th;
       
        public LogInPacijenta()
        {
            InitializeComponent();
          
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bool ima = false;
                foreach (var karton in globalnaKlasa.klinika17270.ListaKartona)
                {
                    if (karton.Jmbg == textBox1.Text) ima = true;
                }
                if (!ima)
                {
                   errorProvider1.SetError(textBox1, "Greška!");
                   throw new Exception ("Nepostojeći JMBG!");
                }
                if (textBox1.TextLength == 0)
                {
                    errorProvider1.SetError(textBox1, "Greška");
                    throw new Exception("Nepotpuni podaci!");

                }
                if (textBox1.TextLength != 0)
                {
                    errorProvider1.SetError(textBox1, "");
                    toolStripLabel1.Text = string.Empty;
                }
                globalnaKlasa.jmbgZaPacijenta = textBox1.Text;
                this.Close();
                th = new Thread(otvoriNovu);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            catch (Exception ex)
            {
                toolStripLabel1.Text = ex.Message;
            }
        }
        private void otvoriNovu(object ob)
        {
            Application.Run(new PacijentIzbornik());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void LogInPacijenta_Load(object sender, EventArgs e)
        {
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            bool jmbg = globalnaKlasa.validacijaJMBG(textBox1.Text);
            if (!jmbg)
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox1, "Greška!");
                toolStripLabel1.Text = "JMBG mora biti dužine 13 karaktera";
            }
        }

        private void textBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(textBox1, "");
            toolStripLabel1.Text = String.Empty;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void CheckEnter(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                textBox1_Validating(sender, new CancelEventArgs());
             
                button1_Click(sender, e);
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }
}

