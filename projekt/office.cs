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
    public partial class office : Form
    {
        private konta konto;
        private bool istnieje;
        private const string Path = @"uzytkownicy.txt";
        private int x;


        public office()
        {
            InitializeComponent();
            konto = new konta();
            istnieje = false;
            x = 0;
            konto.typ = "default";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "office";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "staff";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            konto.typ = "user";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (login.Text == "" || haslo.Text == "" || imie.Text == "" || nazwisko.Text == "" || email.Text == "" || konto.typ == "default")
            {
                MessageBox.Show("Podaj wszystkie dane", "Uwaga");
            }
            else
            {
                konto.login = login.Text;
                konto.haslo = haslo.Text;
                konto.imie = imie.Text;
                konto.nazwisko = nazwisko.Text;
                konto.email = email.Text;

                string linia;
                string[] slowa;
                slowa = new string[6];
                FileStream lic = new FileStream(Path, FileMode.Open, FileAccess.Read);
                StreamReader licz = new StreamReader(lic);
                while (licz.ReadLine() != null) { x++; }
                lic.Close();
                lic.Dispose();
                FileStream sp = new FileStream(Path, FileMode.Open, FileAccess.Read);
                StreamReader sprawdz = new StreamReader(sp);
                for (int i = 0; i < x; i++)
                {
                    linia = sprawdz.ReadLine();
                    if (linia == "") { continue; }
                    else
                    {
                        slowa = linia.Split(' ');
                        if (konto.login == slowa[0])
                        {
                            MessageBox.Show("Podany login jest zajęty", "Uwaga");
                            istnieje = true;
                            break;
                        }
                        if (konto.email == slowa[5])
                        {
                            MessageBox.Show("Istnieje konto z podanym adresem Email");
                            istnieje = true;
                            break;
                        }
                    }

                }
                if (istnieje == false)
                {
                    sp.Close();
                    sp.Dispose();
                    string dane = konto.login + " " + konto.haslo + " " + konto.typ + " " + konto.imie + " " + konto.nazwisko + " " + konto.email;
                    using (StreamWriter w = File.AppendText(Path))
                    {
                        w.WriteLine(dane);
                        w.Dispose();
                        w.Close();
                    }
                    MessageBox.Show("Dodano konto", "Konta");
                }
            }
        }
    }
}
