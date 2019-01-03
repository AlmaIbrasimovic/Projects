namespace Zadaca1
{
    partial class PopunjavanjeKartona
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopunjavanjeKartona));
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.richTextBox3 = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.richTextBox4 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(107, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(369, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Odaberite pacijenta za kojeg želite popuniti karton";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(110, 81);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(366, 21);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Validating += new System.ComponentModel.CancelEventHandler(this.comboBox1_Validating);
            this.comboBox1.Validated += new System.EventHandler(this.comboBox1_Validated);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(22, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(186, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Datum zadnjeg pregleda:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(22, 249);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(141, 16);
            this.label5.TabIndex = 5;
            this.label5.Text = "Prethodne bolesti:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(233, 189);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(243, 20);
            this.dateTimePicker1.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Georgia", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(22, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(196, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Popunite sljedeće podatke";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(559, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 16);
            this.label7.TabIndex = 11;
            this.label7.Text = "Alergije:";
            // 
            // richTextBox2
            // 
            this.richTextBox2.BackColor = System.Drawing.Color.White;
            this.richTextBox2.Location = new System.Drawing.Point(755, 63);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(243, 66);
            this.richTextBox2.TabIndex = 12;
            this.richTextBox2.Text = "";
            this.richTextBox2.Validating += new System.ComponentModel.CancelEventHandler(this.richTextBox2_Validating);
            this.richTextBox2.Validated += new System.EventHandler(this.richTextBox2_Validated);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(559, 189);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(184, 16);
            this.label8.TabIndex = 13;
            this.label8.Text = "Terapije koje je koristio:";
            // 
            // richTextBox3
            // 
            this.richTextBox3.BackColor = System.Drawing.Color.White;
            this.richTextBox3.Location = new System.Drawing.Point(755, 160);
            this.richTextBox3.Name = "richTextBox3";
            this.richTextBox3.Size = new System.Drawing.Size(243, 66);
            this.richTextBox3.TabIndex = 14;
            this.richTextBox3.Text = "";
            this.richTextBox3.Validating += new System.ComponentModel.CancelEventHandler(this.richTextBox3_Validating);
            this.richTextBox3.Validated += new System.EventHandler(this.richTextBox3_Validated);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(559, 294);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(140, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "Mišljenja doktora:";
            // 
            // richTextBox4
            // 
            this.richTextBox4.BackColor = System.Drawing.Color.White;
            this.richTextBox4.Location = new System.Drawing.Point(755, 263);
            this.richTextBox4.Name = "richTextBox4";
            this.richTextBox4.Size = new System.Drawing.Size(243, 66);
            this.richTextBox4.TabIndex = 16;
            this.richTextBox4.Text = "";
            this.richTextBox4.Validating += new System.ComponentModel.CancelEventHandler(this.richTextBox4_Validating);
            this.richTextBox4.Validated += new System.EventHandler(this.richTextBox4_Validated);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(233, 382);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(168, 43);
            this.button1.TabIndex = 17;
            this.button1.Text = "Popuni";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.CausesValidation = false;
            this.button2.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(531, 382);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(168, 43);
            this.button2.TabIndex = 18;
            this.button2.Text = "Izlaz";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 448);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1031, 25);
            this.toolStrip1.TabIndex = 19;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Red;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(0, 22);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Location = new System.Drawing.Point(233, 244);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(243, 66);
            this.richTextBox1.TabIndex = 20;
            this.richTextBox1.Text = "";
            this.richTextBox1.Validating += new System.ComponentModel.CancelEventHandler(this.richTextBox1_Validating);
            this.richTextBox1.Validated += new System.EventHandler(this.richTextBox1_Validated);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // PopunjavanjeKartona
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1031, 473);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.richTextBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.richTextBox3);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.richTextBox2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PopunjavanjeKartona";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Popunjavanje kartona";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox richTextBox3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox richTextBox4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}