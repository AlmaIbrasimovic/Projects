using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zadaca1.Forme;

namespace Zadaca1
{
    public partial class OstaliForma : Form
    {
        List<Pacijent> pacijenti = new List<Pacijent>();
        Klinika klinika17270 = new Klinika();
        Registracija childForma = new Registracija();
        MdiClient klijent = new MdiClient();
        
        public OstaliForma()
        {
            InitializeComponent();
            klijent = Controls.OfType<MdiClient>().First();
            klijent.GotFocus += (s, e) => {
                if (!MdiChildren.Any(x => x.Visible)) klijent.SendToBack();
            };
        }

        private void OstaliForma_Load(object sender, EventArgs e)
        {
            IsMdiContainer = true;
            childForma.MdiParent = this;
          /*  DateTime datRodjenja = new DateTime(1996, 10, 23);
            DateTime datPrijema = new DateTime(2017, 12, 9);
            NormalniSlucajevi novi = new NormalniSlucajevi("Alma", "Ibrašimović", datRodjenja, "23", "Žensko", datPrijema, "Neudata");
            pacijenti.Add(novi);
            NormalniSlucajevi stari = new NormalniSlucajevi("Zlata", "Karić", new DateTime(1997, 12, 5), "12", "Žensko", new DateTime(2017, 10, 22), "Udata");
            pacijenti.Add(stari);
            NormalniSlucajevi kk = new NormalniSlucajevi("Emina", "Ćatić", new DateTime(1997, 5, 15), "2", "Žensko", new DateTime(2017, 2, 22), "Neudata");
            pacijenti.Add(kk);
            NormalniSlucajevi nk = new NormalniSlucajevi("Kurt", "Cobain", new DateTime(1967, 2, 20), "3", "Muško", new DateTime(2017, 10, 22), "Razveden");
            pacijenti.Add(nk);
            klinika17270.registrujNovogPacijenta(novi); klinika17270.registrujNovogPacijenta(stari); klinika17270.registrujNovogPacijenta(nk); klinika17270.registrujNovogPacijenta(kk);
    */  
    }
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Registracija nov = new Registracija { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }
        private void PrikaziFormu(Form childForm)
        {
            klijent.BringToFront();
            childForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            KartonForma nov = new KartonForma() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PopunjavanjeKartona nov = new PopunjavanjeKartona() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PrikazKartona nov = new PrikazKartona() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Mrtvacnica nov = new Mrtvacnica() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Redovi nov = new Redovi() {MdiParent = this};
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 objekt = new Form1();
            objekt.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Pretrage nov = new Pretrage() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Racun nov = new Racun() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Brisanje nov = new Brisanje() { MdiParent = this };
            nov.MdiParent = this;
            PrikaziFormu(nov);
        }
    }
}
