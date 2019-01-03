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
    public partial class Mrtvacnica : Form
    {
        public Mrtvacnica()
        {
            InitializeComponent();
            foreach (var VARIABLE in globalnaKlasa.klinika17270.PreminuliPacijenti)
            {
                richTextBox1.AppendText(VARIABLE.ispisiString());
                richTextBox1.AppendText("\n");
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
