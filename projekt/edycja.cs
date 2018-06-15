using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class edycja : Form
    {
        private konta[] konto;
        private int x,znane;
        private bool istnieje;
        private string typ;

        public edycja()
        {
            InitializeComponent();
            line_email.Hide();
            line_haslo.Hide();
            line_login.Hide();
            button2.Hide();
            label2.Hide();
            label3.Hide();
            label4.Hide();
            label5.Hide();
            radioButton1.Hide();
            radioButton2.Hide();
            radioButton3.Hide();
            x = 0;
            znane = 0;
            istnieje = false;
            typ = "default";
            FileStream lic = new FileStream(@"uzytkownicy.txt", FileMode.Open, FileAccess.Read);
            StreamReader licz = new StreamReader(lic);
            while (licz.ReadLine() != null) { x++; }
            lic.Close();
            lic.Dispose();
            konto = new konta[x];
            for(int i=0;i<x;i++)
            {
                konto[i] = new konta();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
                
        private void button1_Click(object sender, EventArgs e)
        {
            string linia;
            string[] slowa;
            slowa = new string[6];
            FileStream ccc = new FileStream(@"uzytkownicy.txt", FileMode.Open, FileAccess.Read);
            StreamReader eee = new StreamReader(ccc);
            for (int i = 0; i < x; i++)
            {
                linia = eee.ReadLine();
                if (linia == "" ||linia==" ") { continue; }
                else
                {
                    slowa = linia.Split(' ');
                    konto[i].login = slowa[0];
                    konto[i].haslo = slowa[1];
                    konto[i].typ = slowa[2];
                    konto[i].imie = slowa[3];
                    konto[i].nazwisko = slowa[4];
                    konto[i].email = slowa[5];
                }
            }
            for (int i = 0; i < x; i++)
            {
                if (konto[i].login == old.Text && konto[i].typ != "user")
                {
                    istnieje = true;
                    znane = i;
                    line_email.Show();
                    line_haslo.Show();
                    line_login.Show();
                    button2.Show();
                    label2.Show();
                    label3.Show();
                    label4.Show();
                    label5.Show();
                    radioButton1.Show();
                    radioButton2.Show();
                    radioButton3.Show();
                    old.Hide();
                    label1.Hide();
                    button1.Hide();
                }
            }
        
            
            if(istnieje==false)
            { MessageBox.Show("Podane konto nie istnieje", "Uwaga"); }
            ccc.Close();
            ccc.Dispose();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            typ = "admin";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            typ = "office";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            typ = "staff";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (typ == "default")
            {
                MessageBox.Show("Wybierz typ konta", "Uwaga");
            }
            else
            {
                if (line_login.Text != "" && line_login.Text != " ")
                {
                    konto[znane].login = line_login.Text;
                }

                if (line_haslo.Text != "" && line_haslo.Text != " ")
                {
                    konto[znane].haslo = line_haslo.Text;
                }

                if (line_email.Text != "" && line_email.Text != " ")
                {
                    konto[znane].email = line_email.Text;
                }
                konto[znane].typ = typ;
                string linijka;
                string[] wyr = new string[x];
                for(int i=0;i<x;i++)
                {
                    linijka = konto[i].login + " " + konto[i].haslo + " " + konto[i].typ + " " + konto[i].imie + " " + konto[i].nazwisko + " " + konto[i].email;
                    wyr[i] = linijka;
                }
                File.WriteAllLines(@"uzytkownicy.txt", wyr);
                MessageBox.Show("Zmieniono dane", "Uwaga");
                this.Hide();
            }
        }
    }
}
