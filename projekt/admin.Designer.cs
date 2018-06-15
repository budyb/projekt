namespace projekt
{
    partial class admin
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
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kontaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edytujKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuńKontoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.samochodyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dodajSamochódToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(528, 391);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Wyjdź";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kontaToolStripMenuItem,
            this.samochodyToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(624, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kontaToolStripMenuItem
            // 
            this.kontaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajKontoToolStripMenuItem,
            this.edytujKontoToolStripMenuItem,
            this.usuńKontoToolStripMenuItem});
            this.kontaToolStripMenuItem.Name = "kontaToolStripMenuItem";
            this.kontaToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.kontaToolStripMenuItem.Text = "Konta";
            // 
            // dodajKontoToolStripMenuItem
            // 
            this.dodajKontoToolStripMenuItem.Name = "dodajKontoToolStripMenuItem";
            this.dodajKontoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.dodajKontoToolStripMenuItem.Text = "Dodaj Konto";
            this.dodajKontoToolStripMenuItem.Click += new System.EventHandler(this.dodajKontoToolStripMenuItem_Click);
            // 
            // edytujKontoToolStripMenuItem
            // 
            this.edytujKontoToolStripMenuItem.Name = "edytujKontoToolStripMenuItem";
            this.edytujKontoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.edytujKontoToolStripMenuItem.Text = "Edytuj Konto";
            this.edytujKontoToolStripMenuItem.Click += new System.EventHandler(this.edytujKontoToolStripMenuItem_Click);
            // 
            // usuńKontoToolStripMenuItem
            // 
            this.usuńKontoToolStripMenuItem.Name = "usuńKontoToolStripMenuItem";
            this.usuńKontoToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.usuńKontoToolStripMenuItem.Text = "Usuń Konto";
            this.usuńKontoToolStripMenuItem.Click += new System.EventHandler(this.usuńKontoToolStripMenuItem_Click);
            // 
            // samochodyToolStripMenuItem
            // 
            this.samochodyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dodajSamochódToolStripMenuItem});
            this.samochodyToolStripMenuItem.Name = "samochodyToolStripMenuItem";
            this.samochodyToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.samochodyToolStripMenuItem.Text = "Samochody";
            // 
            // dodajSamochódToolStripMenuItem
            // 
            this.dodajSamochódToolStripMenuItem.Name = "dodajSamochódToolStripMenuItem";
            this.dodajSamochódToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.dodajSamochódToolStripMenuItem.Text = "Dodaj Samochód";
            this.dodajSamochódToolStripMenuItem.Click += new System.EventHandler(this.dodajSamochódToolStripMenuItem_Click);
            // 
            // admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1920, 1080);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "admin";
            this.Text = "admin";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kontaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajKontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem edytujKontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuńKontoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem samochodyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dodajSamochódToolStripMenuItem;
    }
}