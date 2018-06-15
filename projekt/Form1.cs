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
    public partial class Form1 : Form
    {
        private const string Path = @"uzytkownicy.txt";

        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x = 0;
            String password,loign;
            string linia;
            string[] slowa;
            slowa = new string[6];
            password = haslo.Text;
            loign = login.Text;
            bool zalogowano=false;
            konta konto = new konta();
            FileStream lic = new FileStream(Path, FileMode.Open, FileAccess.Read);
            StreamReader licz = new StreamReader(lic);
            while (licz.ReadLine()!=null) { x++; }
            
            FileStream pl = new FileStream(Path, FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(pl);
            for (int i=0;i<x; i++)
            {
                linia = file.ReadLine();

                 slowa = linia.Split(' ');
                if (slowa[0] == loign && slowa[1] == password)
                {
                    zalogowano = true;
                    konto.typ = slowa[2];
                    if(konto.typ=="admin")
                    {
                        
                        
                        licz.Close();
                        file.Close();
                        pl.Dispose();
                        lic.Dispose();
                        lic.Close();
                        pl.Close();
                        this.Hide();
                        admin panel = new admin();
                        panel.ShowDialog();
                        break;
                    }
                    if (konto.typ == "user")
                    {
                        
                        licz.Close();
                        file.Close();
                        pl.Dispose();
                        lic.Dispose();
                        lic.Close();
                        pl.Close();
                        this.Hide();
                        user menu = new user(loign);
                        menu.ShowDialog();
                        break;
                    }
                    if (konto.typ == "staff")
                    {
                        
                        licz.Close();
                        file.Close();
                        pl.Dispose();
                        lic.Dispose();
                        lic.Close();
                        pl.Close();
                        this.Hide();
                        staff obsluga = new staff();
                        obsluga.ShowDialog();
                        break;
                    }
                    if (konto.typ == "office")
                    {
                        
                        licz.Close();
                        file.Close();
                        pl.Dispose();
                        lic.Dispose();
                        lic.Close();
                        pl.Close();
                        this.Hide();
                        office biuro = new office();
                        biuro.ShowDialog();
                        break;
                    }
                }
                else { continue; }
            }
            if (zalogowano == false)
            {
                MessageBox.Show("Nie udało się zalogować", "Błąd");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            rejestracja rej = new rejestracja();
            rej.ShowDialog();
        }
    }
}
