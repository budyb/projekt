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
    public partial class panel_kont : Form
    {
        private const string Path = @"uzytkownicy.txt";
        konta konto= new konta();
        private int x;
        public panel_kont()
        {
            InitializeComponent();
            x = 0;
        }
                
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "admin";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "office";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "staff";
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "user";
        }
        private void button2_Click(object sender, EventArgs e)
        {
            bool istnieje = false;
            if(line_login.Text==""||line_login.Text==" "||line_haslo.Text==""||line_haslo.Text==" "||line_imie.Text==""||line_imie.Text==" "||line_nazwisko.Text==""||line_nazwisko.Text==" "||line_email.Text==""||line_email.Text==" ")
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Uwaga");
            }
            else if (konto.typ!="admin" && konto.typ!="office" && konto.typ!="staff" && konto.typ!="user")
            {
                MessageBox.Show("Podaj typ konta", "Uwaga");
            }
            else
            {
                FileStream lic = new FileStream(Path, FileMode.Open, FileAccess.Read);
                StreamReader licz = new StreamReader(lic);
                while (licz.ReadLine() != null) { x++; }
                lic.Close();
                lic.Dispose();
                string linia;
                string[] slowa;
                slowa = new string[6];
                FileStream sp = new FileStream(Path, FileMode.Open, FileAccess.Read);
                StreamReader sprawdz = new StreamReader(sp);
                for(int i =0; i<x;i++)
                {
                        linia = sprawdz.ReadLine();
                    if (linia == "") { continue; }
                    else
                    {
                        slowa = linia.Split(' ');

                        if (line_login.Text == slowa[0])
                        {
                            MessageBox.Show("Podany login jest zajęty", "Uwaga");
                            istnieje = true;
                            break;
                        }
                        if (line_email.Text == slowa[5])
                        {
                            MessageBox.Show("Podany email jest zajęty", "Uwaga");
                            istnieje = true;
                            break;
                        }
                    }
                    
                 }
                sprawdz.Close();
                sp.Close();
                sprawdz.Dispose();
                sp.Dispose();
                
                
                if (istnieje==false)
                {
                    konto.login = line_login.Text;
                    konto.haslo = line_haslo.Text;
                    konto.imie = line_imie.Text;
                    konto.nazwisko = line_nazwisko.Text;
                    konto.email = line_email.Text;
                    string dane = konto.login + " " + konto.haslo + " " + konto.typ + " " + konto.imie + " " + konto.nazwisko + " " + konto.email;

                                        
                    using (StreamWriter w = File.AppendText(Path))
                    {
                        w.WriteLine(dane);
                        w.Dispose();
                        w.Close();
                    }
                    MessageBox.Show("Dodano konto");           
                    this.Hide();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
