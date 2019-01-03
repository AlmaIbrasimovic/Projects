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
    public partial class Info : Form
    {
        public Info()
        {
            InitializeComponent();
            
            richTextBox1.AppendText("Radno vrijeme: 08:00 - 23:00, svaki dan.\nAdresa klinike: Ruždija 4, Fojnica\nKontakt telefon: +38730897564\n\n\nSVOJE ZDRAVLJE PREPUSTITE U NAŠE RUKE!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }
    }
}
