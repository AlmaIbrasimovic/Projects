namespace Zadaca1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.DobrodosliLabel = new System.Windows.Forms.Label();
            this.PrijavaGroup = new System.Windows.Forms.GroupBox();
            this.PacijentRadio = new System.Windows.Forms.RadioButton();
            this.OstaloRadio = new System.Windows.Forms.RadioButton();
            this.DoktorRadio = new System.Windows.Forms.RadioButton();
            this.ImeLabel = new System.Windows.Forms.Label();
            this.LozinkaLabel = new System.Windows.Forms.Label();
            this.ImeText = new System.Windows.Forms.TextBox();
            this.LozinkaText = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.IzlazButton = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.PrijavaGroup.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // DobrodosliLabel
            // 
            this.DobrodosliLabel.AutoSize = true;
            this.DobrodosliLabel.BackColor = System.Drawing.Color.Transparent;
            this.DobrodosliLabel.Font = new System.Drawing.Font("Georgia", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DobrodosliLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.DobrodosliLabel.Location = new System.Drawing.Point(154, 42);
            this.DobrodosliLabel.Name = "DobrodosliLabel";
            this.DobrodosliLabel.Size = new System.Drawing.Size(249, 43);
            this.DobrodosliLabel.TabIndex = 0;
            this.DobrodosliLabel.Text = "Dobrodošli!";
            // 
            // PrijavaGroup
            // 
            this.PrijavaGroup.BackColor = System.Drawing.Color.Transparent;
            this.PrijavaGroup.Controls.Add(this.PacijentRadio);
            this.PrijavaGroup.Controls.Add(this.OstaloRadio);
            this.PrijavaGroup.Controls.Add(this.DoktorRadio);
            this.PrijavaGroup.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PrijavaGroup.ForeColor = System.Drawing.Color.DarkRed;
            this.PrijavaGroup.Location = new System.Drawing.Point(166, 200);
            this.PrijavaGroup.Name = "PrijavaGroup";
            this.PrijavaGroup.Size = new System.Drawing.Size(237, 136);
            this.PrijavaGroup.TabIndex = 1;
            this.PrijavaGroup.TabStop = false;
            this.PrijavaGroup.Text = "Prijavite se:";
            // 
            // PacijentRadio
            // 
            this.PacijentRadio.AutoSize = true;
            this.PacijentRadio.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PacijentRadio.Location = new System.Drawing.Point(84, 83);
            this.PacijentRadio.Name = "PacijentRadio";
            this.PacijentRadio.Size = new System.Drawing.Size(78, 19);
            this.PacijentRadio.TabIndex = 2;
            this.PacijentRadio.Text = "Pacijent";
            this.PacijentRadio.UseVisualStyleBackColor = true;
            // 
            // OstaloRadio
            // 
            this.OstaloRadio.AutoSize = true;
            this.OstaloRadio.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OstaloRadio.Location = new System.Drawing.Point(84, 58);
            this.OstaloRadio.Name = "OstaloRadio";
            this.OstaloRadio.Size = new System.Drawing.Size(114, 19);
            this.OstaloRadio.TabIndex = 1;
            this.OstaloRadio.Text = "Ostalo osoblje";
            this.OstaloRadio.UseVisualStyleBackColor = true;
            // 
            // DoktorRadio
            // 
            this.DoktorRadio.AutoSize = true;
            this.DoktorRadio.Checked = true;
            this.DoktorRadio.Font = new System.Drawing.Font("Georgia", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoktorRadio.Location = new System.Drawing.Point(84, 33);
            this.DoktorRadio.Name = "DoktorRadio";
            this.DoktorRadio.Size = new System.Drawing.Size(70, 19);
            this.DoktorRadio.TabIndex = 0;
            this.DoktorRadio.TabStop = true;
            this.DoktorRadio.Text = "Doktor";
            this.DoktorRadio.UseVisualStyleBackColor = true;
            // 
            // ImeLabel
            // 
            this.ImeLabel.AutoSize = true;
            this.ImeLabel.BackColor = System.Drawing.Color.Transparent;
            this.ImeLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.ImeLabel.Location = new System.Drawing.Point(12, 391);
            this.ImeLabel.Name = "ImeLabel";
            this.ImeLabel.Size = new System.Drawing.Size(123, 16);
            this.ImeLabel.TabIndex = 2;
            this.ImeLabel.Text = "Korisničko ime:";
            // 
            // LozinkaLabel
            // 
            this.LozinkaLabel.AutoSize = true;
            this.LozinkaLabel.BackColor = System.Drawing.Color.Transparent;
            this.LozinkaLabel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LozinkaLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.LozinkaLabel.Location = new System.Drawing.Point(12, 448);
            this.LozinkaLabel.Name = "LozinkaLabel";
            this.LozinkaLabel.Size = new System.Drawing.Size(71, 16);
            this.LozinkaLabel.TabIndex = 3;
            this.LozinkaLabel.Text = "Lozinka:";
            // 
            // ImeText
            // 
            this.ImeText.Location = new System.Drawing.Point(166, 387);
            this.ImeText.Name = "ImeText";
            this.ImeText.Size = new System.Drawing.Size(237, 20);
            this.ImeText.TabIndex = 4;
            this.ImeText.Validating += new System.ComponentModel.CancelEventHandler(this.ImeText_Validating);
            this.ImeText.Validated += new System.EventHandler(this.ImeText_Validated);
            // 
            // LozinkaText
            // 
            this.LozinkaText.Location = new System.Drawing.Point(166, 448);
            this.LozinkaText.Name = "LozinkaText";
            this.LozinkaText.PasswordChar = '*';
            this.LozinkaText.Size = new System.Drawing.Size(237, 20);
            this.LozinkaText.TabIndex = 5;
            this.LozinkaText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CheckEnter);
            this.LozinkaText.Validating += new System.ComponentModel.CancelEventHandler(this.LozinkaText_Validating);
            this.LozinkaText.Validated += new System.EventHandler(this.LozinkaText_Validated);
            // 
            // OKButton
            // 
            this.OKButton.BackColor = System.Drawing.Color.DarkRed;
            this.OKButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OKButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.OKButton.Location = new System.Drawing.Point(166, 528);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 35);
            this.OKButton.TabIndex = 6;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // IzlazButton
            // 
            this.IzlazButton.BackColor = System.Drawing.Color.DarkRed;
            this.IzlazButton.CausesValidation = false;
            this.IzlazButton.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IzlazButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.IzlazButton.Location = new System.Drawing.Point(328, 528);
            this.IzlazButton.Name = "IzlazButton";
            this.IzlazButton.Size = new System.Drawing.Size(75, 35);
            this.IzlazButton.TabIndex = 7;
            this.IzlazButton.Text = "Izlaz";
            this.IzlazButton.UseVisualStyleBackColor = false;
            this.IzlazButton.Click += new System.EventHandler(this.IzlazButton_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 590);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.statusStrip1.Size = new System.Drawing.Size(507, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLabel1.ForeColor = System.Drawing.Color.DarkRed;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkRate = 200;
            this.errorProvider1.ContainerControl = this;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(507, 612);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.IzlazButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.LozinkaText);
            this.Controls.Add(this.ImeText);
            this.Controls.Add(this.LozinkaLabel);
            this.Controls.Add(this.ImeLabel);
            this.Controls.Add(this.PrijavaGroup);
            this.Controls.Add(this.DobrodosliLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Naša Mala Klinika";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.PrijavaGroup.ResumeLayout(false);
            this.PrijavaGroup.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DobrodosliLabel;
        private System.Windows.Forms.GroupBox PrijavaGroup;
        private System.Windows.Forms.RadioButton PacijentRadio;
        private System.Windows.Forms.RadioButton OstaloRadio;
        private System.Windows.Forms.RadioButton DoktorRadio;
        private System.Windows.Forms.Label ImeLabel;
        private System.Windows.Forms.Label LozinkaLabel;
        private System.Windows.Forms.TextBox ImeText;
        private System.Windows.Forms.TextBox LozinkaText;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button IzlazButton;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}