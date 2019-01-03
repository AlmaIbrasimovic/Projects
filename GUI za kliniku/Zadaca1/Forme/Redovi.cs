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
    public partial class Redovi : Form
    {
        public Redovi()
        {
            InitializeComponent();
            comboBox1.Text = "--Odaberite--";
            comboBox1.Items.Add("Ortopedska");
            comboBox1.Items.Add("Kardiološka");
            comboBox1.Items.Add("Dermatološka");
            comboBox1.Items.Add("Internistička");
            comboBox1.Items.Add("Otorinolaringološka");
            comboBox1.Items.Add("Oftamološka");
            comboBox1.Items.Add("Laboratorija");
            comboBox1.Items.Add("Stomatološka");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
                richTextBox1.Clear();
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

        private void comboBox1_Click(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
