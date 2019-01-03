namespace Zadaca1
{
    partial class Info
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Kardiološka");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Oftamološka");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Stomatološka");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Laboratorija");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Dermatološka");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Otorinolaringološka");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Internistička");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Ortopedska");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Ordinacije", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8});
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Veljko Kunić");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Lili Štriga");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Ante Guzina");
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Florijan Gavran");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Franjo Slaviček");
            System.Windows.Forms.TreeNode treeNode15 = new System.Windows.Forms.TreeNode("sestra Helga");
            System.Windows.Forms.TreeNode treeNode16 = new System.Windows.Forms.TreeNode("Toni Grgeč");
            System.Windows.Forms.TreeNode treeNode17 = new System.Windows.Forms.TreeNode("Bogo Moljka");
            System.Windows.Forms.TreeNode treeNode18 = new System.Windows.Forms.TreeNode("Doktori", new System.Windows.Forms.TreeNode[] {
            treeNode10,
            treeNode11,
            treeNode12,
            treeNode13,
            treeNode14,
            treeNode15,
            treeNode16,
            treeNode17});
            System.Windows.Forms.TreeNode treeNode19 = new System.Windows.Forms.TreeNode("Šemsudin Poplava");
            System.Windows.Forms.TreeNode treeNode20 = new System.Windows.Forms.TreeNode("Mile Car");
            System.Windows.Forms.TreeNode treeNode21 = new System.Windows.Forms.TreeNode("Grospićka");
            System.Windows.Forms.TreeNode treeNode22 = new System.Windows.Forms.TreeNode("Ostali uposlenici", new System.Windows.Forms.TreeNode[] {
            treeNode19,
            treeNode20,
            treeNode21});
            System.Windows.Forms.TreeNode treeNode23 = new System.Windows.Forms.TreeNode("Naša Mala Klinika", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode18,
            treeNode22});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Info));
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(602, 400);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Izlaz";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "Node2";
            treeNode1.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode1.Text = "Kardiološka";
            treeNode2.Name = "Node3";
            treeNode2.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode2.Text = "Oftamološka";
            treeNode3.Name = "Node4";
            treeNode3.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode3.Text = "Stomatološka";
            treeNode4.Name = "Node5";
            treeNode4.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode4.Text = "Laboratorija";
            treeNode5.Name = "Node6";
            treeNode5.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode5.Text = "Dermatološka";
            treeNode6.Name = "Node7";
            treeNode6.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode6.Text = "Otorinolaringološka";
            treeNode7.Name = "Node8";
            treeNode7.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode7.Text = "Internistička";
            treeNode8.Name = "Node9";
            treeNode8.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode8.Text = "Ortopedska";
            treeNode9.Name = "Node1";
            treeNode9.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode9.Text = "Ordinacije";
            treeNode10.Name = "Node11";
            treeNode10.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode10.Text = "Veljko Kunić";
            treeNode11.Name = "Node12";
            treeNode11.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode11.Text = "Lili Štriga";
            treeNode12.Name = "Node13";
            treeNode12.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode12.Text = "Ante Guzina";
            treeNode13.Name = "Node14";
            treeNode13.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode13.Text = "Florijan Gavran";
            treeNode14.Name = "Node15";
            treeNode14.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode14.Text = "Franjo Slaviček";
            treeNode15.Name = "Node16";
            treeNode15.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode15.Text = "sestra Helga";
            treeNode16.Name = "Node17";
            treeNode16.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode16.Text = "Toni Grgeč";
            treeNode17.Name = "Node18";
            treeNode17.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode17.Text = "Bogo Moljka";
            treeNode18.Name = "Node10";
            treeNode18.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode18.Text = "Doktori";
            treeNode19.Name = "Node20";
            treeNode19.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode19.Text = "Šemsudin Poplava";
            treeNode20.Name = "Node21";
            treeNode20.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode20.Text = "Mile Car";
            treeNode21.Name = "Node22";
            treeNode21.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode21.Text = "Grospićka";
            treeNode22.Name = "Node19";
            treeNode22.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode22.Text = "Ostali uposlenici";
            treeNode23.BackColor = System.Drawing.Color.White;
            treeNode23.Name = "Naša Mala Klinika";
            treeNode23.NodeFont = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            treeNode23.Text = "Naša Mala Klinika";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode23});
            this.treeView1.Size = new System.Drawing.Size(305, 435);
            this.treeView1.TabIndex = 2;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.White;
            this.richTextBox1.Font = new System.Drawing.Font("Mistral", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTextBox1.Location = new System.Drawing.Point(311, 0);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(413, 394);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 435);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Info";
            this.Text = "Info";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}