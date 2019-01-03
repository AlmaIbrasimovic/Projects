using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Zadaca1
{
    public partial class Slika : UserControl
    {
        public Slika()
        {
            InitializeComponent();
        }

        public DateTime datumSlike
        {
            get { return dateTimePicker1.Value.Date; }
            set { dateTimePicker1.Value = value; }
        }

        public Image slika
        {
            get { return pictureBox1.BackgroundImage; }
            set { pictureBox1.BackgroundImage = value; }
        }

        public Image dajSliku()
        {
            return pictureBox1.BackgroundImage;
        }
        private void Slika_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
