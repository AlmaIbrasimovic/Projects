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
    public partial class SviPacijenti : Form
    {
        public SviPacijenti()
        {
            InitializeComponent();
            foreach (var VARIABLE in globalnaKlasa.klinika17270.ListaPacijenata)
            {
                richTextBox1.AppendText(VARIABLE.ispisiString());
                richTextBox1.AppendText("\n");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
