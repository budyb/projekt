namespace projekt
{
    partial class rejestracja
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.line_login = new System.Windows.Forms.TextBox();
            this.line_haslo = new System.Windows.Forms.TextBox();
            this.line_imie = new System.Windows.Forms.TextBox();
            this.line_nazwisko = new System.Windows.Forms.TextBox();
            this.line_email = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Login";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Hasło";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(100, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Imię";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(100, 199);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Nazwisko";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(100, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Email";
            // 
            // line_login
            // 
            this.line_login.Location = new System.Drawing.Point(300, 112);
            this.line_login.Name = "line_login";
            this.line_login.Size = new System.Drawing.Size(100, 20);
            this.line_login.TabIndex = 5;
            // 
            // line_haslo
            // 
            this.line_haslo.Location = new System.Drawing.Point(300, 140);
            this.line_haslo.Name = "line_haslo";
            this.line_haslo.Size = new System.Drawing.Size(100, 20);
            this.line_haslo.TabIndex = 6;
            // 
            // line_imie
            // 
            this.line_imie.Location = new System.Drawing.Point(300, 166);
            this.line_imie.Name = "line_imie";
            this.line_imie.Size = new System.Drawing.Size(100, 20);
            this.line_imie.TabIndex = 7;
            // 
            // line_nazwisko
            // 
            this.line_nazwisko.Location = new System.Drawing.Point(300, 192);
            this.line_nazwisko.Name = "line_nazwisko";
            this.line_nazwisko.Size = new System.Drawing.Size(100, 20);
            this.line_nazwisko.TabIndex = 8;
            // 
            // line_email
            // 
            this.line_email.Location = new System.Drawing.Point(300, 218);
            this.line_email.Name = "line_email";
            this.line_email.Size = new System.Drawing.Size(100, 20);
            this.line_email.TabIndex = 9;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(193, 387);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 10;
            this.button1.Text = "Rejestracja";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(418, 387);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Anuluj";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rejestracja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.line_email);
            this.Controls.Add(this.line_nazwisko);
            this.Controls.Add(this.line_imie);
            this.Controls.Add(this.line_haslo);
            this.Controls.Add(this.line_login);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximumSize = new System.Drawing.Size(640, 480);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "rejestracja";
            this.Text = "rejestracja";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox line_login;
        private System.Windows.Forms.TextBox line_haslo;
        private System.Windows.Forms.TextBox line_imie;
        private System.Windows.Forms.TextBox line_nazwisko;
        private System.Windows.Forms.TextBox line_email;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}