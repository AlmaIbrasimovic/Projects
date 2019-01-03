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
    public partial class Pretrage : Form
    {
        Thread th;
        public Pretrage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Pretrage_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.Close();
                th = new Thread(otvoriNovuPacijent);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            if (radioButton2.Checked)
            {

                this.Close();
                th = new Thread(otvoriNovu);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
        }
        private void otvoriNovuPacijent(object ob)
        {
            Application.Run(new Novo());
        }
        private void otvoriNovu(object ob)
        {
            Application.Run(new SviPacijenti());
        }
    }
}
