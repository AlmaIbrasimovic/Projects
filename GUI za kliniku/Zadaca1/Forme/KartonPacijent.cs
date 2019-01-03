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
    public partial class KartonPacijent : Form
    {
        public KartonPacijent()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void KartonPacijent_Load(object sender, EventArgs e)
        {
            string text = globalnaKlasa.jmbgZaPacijenta;
            richTextBox1.AppendText(globalnaKlasa.klinika17270.pretragaKartona(text));
        }
    }
}
