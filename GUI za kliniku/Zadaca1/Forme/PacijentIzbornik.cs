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
    public partial class PacijentIzbornik : Form
    {
        KartonPacijent childForma = new KartonPacijent();
        MdiClient klijent = new MdiClient();
       
        public PacijentIzbornik()
        {
            InitializeComponent();
            klijent = Controls.OfType<MdiClient>().First();
            klijent.GotFocus += (s, e) => {
                if (!MdiChildren.Any(x => x.Visible)) klijent.SendToBack();
            };
            bool spol = false;
            string imePrezime = String.Empty;
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                if (VARIABLE._JMBG == globalnaKlasa.jmbgZaPacijenta)
                {
                    if (VARIABLE._Spol == "Žensko") spol = true;
                    imePrezime = VARIABLE._Ime + " " + VARIABLE._Prezime;
                }
            }
            if (spol) label3.Text = "Dobro došla, " + imePrezime;
            else label3.Text = "Dobrodošao, " + imePrezime;
        }

        private void PacijentIzbornik_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            childForma.MdiParent = this;
           
        }
        private void PrikaziFormu(Form childForm)
        {
            klijent.BringToFront();
            childForm.Show();
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KartonPacijent nov = new KartonPacijent() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ZakazaniPregledi nov = new ZakazaniPregledi() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Redovi nov = new Redovi(){ MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 objekt = new Form1();
            objekt.Show();
        }
    }
}

