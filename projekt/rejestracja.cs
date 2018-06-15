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
    public partial class rejestracja : Form
    {
        private bool istnieje;
        private const string Path = @"uzytkownicy.txt";
        private string login2, email2;
        konta konto = new konta();
        private int x;
        public rejestracja()
        {
            InitializeComponent();
            istnieje = false;
            x = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            istnieje = false;
            if(line_login.Text==""|| line_login.Text == " " || line_haslo.Text == "" || line_haslo.Text == " " || line_imie.Text == "" || line_imie.Text == " " || line_nazwisko.Text == "" || line_nazwisko.Text == " " || line_email.Text == "" || line_email.Text == " " )
            {
                MessageBox.Show("Wszystkie pola muszą być wypełnione!", "Uwaga");
            }
            else
            {
                login2 = line_login.Text;
                email2 = line_email.Text;
                string linia;
                string[] slowa;
                slowa = new string[6];
                FileStream lic = new FileStream(Path, FileMode.Open, FileAccess.Read);
                StreamReader licz = new StreamReader(lic);
                while (licz.ReadLine() != null) { x++; }

                FileStream sp = new FileStream(Path, FileMode.Open, FileAccess.Read);
                StreamReader sprawdz = new StreamReader(sp);
                for(int i=0;i<x;i++)
                {
                    linia = sprawdz.ReadLine();
                    if (linia == "") { continue; }
                    else
                    {
                        slowa = linia.Split(' ');
                        if (login2 == slowa[0])
                        {
                            MessageBox.Show("Podany login jest zajęty", "Uwaga");
                            istnieje = true;
                            break;
                        }
                        if (email2 == slowa[5])
                        {
                            MessageBox.Show("Istnieje konto z podanym adresem Email");
                            istnieje = true;
                            break;
                        }
                    }
                    
                }
                if(istnieje==false)
                {
                    sp.Close();
                    sp.Dispose();
                    konto.login = login2;
                    konto.haslo = line_haslo.Text;
                    konto.typ = "user";
                    konto.imie = line_imie.Text;
                    konto.nazwisko = line_nazwisko.Text;
                    konto.email = email2;
                    string dane = konto.login + " " + konto.haslo + " " + konto.typ + " " + konto.imie + " " + konto.nazwisko + " " + konto.email;
                    using (StreamWriter w = File.AppendText(Path))
                    {
                        w.WriteLine(dane);
                        w.Dispose();
                        w.Close();
                    }
                    MessageBox.Show("Udało się zarejestrować", "Sukces");
                    this.Close();
                    Show();
                }
            }

        }

        
    }
}
