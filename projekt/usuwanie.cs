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
    public partial class usuwanie : Form
    {
        private konta[] konto;
        private int x;
        private bool exist;

        public usuwanie()
        {
            InitializeComponent();
            exist = false;
            FileStream lic = new FileStream(@"uzytkownicy.txt", FileMode.Open, FileAccess.Read);
            StreamReader licz = new StreamReader(lic);
            while (licz.ReadLine() != null) { x++; }
            lic.Close();
            lic.Dispose();
            konto = new konta[x];
            for (int i = 0; i < x; i++)
            {
                konto[i] = new konta();
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream wcz = new FileStream(@"uzytkownicy.txt", FileMode.Open, FileAccess.Read);
            StreamReader wczytaj = new StreamReader(wcz);
            string linia;
            string[] wyr = new string[6];
            for (int i = 0; i < x; i++)
            {
                linia = wczytaj.ReadLine();
                if(linia==""||linia==" "||linia==null) { continue; }
                else
                {
                    wyr = linia.Split(' ');
                    konto[i].login = wyr[0];
                    konto[i].haslo = wyr[1];
                    konto[i].typ = wyr[2];
                    konto[i].imie = wyr[3];
                    konto[i].nazwisko = wyr[4];
                    konto[i].email = wyr[5];
                    if(konto[i].login==login.Text&&login.Text!="")
                    { i--; exist = true; }
                }
            }
            wcz.Close();
            wcz.Dispose();
            if (exist == true)
            {
                string linijka;
                string[] wy = new string[x];
                for (int i = 0; i < x; i++)
                {
                    linijka = konto[i].login + " " + konto[i].haslo + " " + konto[i].typ + " " + konto[i].imie + " " + konto[i].nazwisko + " " + konto[i].email;
                    wy[i] = linijka;
                }
                File.WriteAllLines(@"uzytkownicy.txt", wy);
                MessageBox.Show("Usunięto konto", "Uwaga");
                this.Hide();
            }
            else if(exist==false)
            { MessageBox.Show("Takie konto nie istnieje", "Usuwanie"); }
        }
    }
}
