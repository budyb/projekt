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
    public partial class zarządzanie : Form
    {
        private string Login;
        private int x, y,nn;
        private konta[] konto;
        private wypozyczenie[] wyp;
        private bool zmiana, log,wolny;

        public zarządzanie(string login)
        {
            InitializeComponent();
            Login = login;
            x = 0;
            y = 0;
            nn = 0;
            zmiana = false;
            log = false;
            wolny = true;
            FileStream lic = new FileStream(@"uzytkownicy.txt", FileMode.Open, FileAccess.Read);
            StreamReader licz = new StreamReader(lic);
            while (licz.ReadLine() != null) { x++; }
            lic.Close();
            lic.Dispose();
            FileStream li = new FileStream(@"rents.txt", FileMode.Open, FileAccess.Read);
            StreamReader licze = new StreamReader(li);
            while (licze.ReadLine() != null) { y++; }
            li.Close();
            li.Dispose();
            konto = new konta[x];
            for(int i=0;i<x;i++)
            {
                konto[i] = new konta();
            }
            wyp = new wypozyczenie[y];
            for(int i=0;i<y;i++)
            {
                wyp[i] = new wypozyczenie();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string linia;
            string[] slowa;
            slowa = new string[6];
            FileStream pl = new FileStream(@"uzytkownicy.txt", FileMode.Open, FileAccess.Read);
            StreamReader file = new StreamReader(pl);
            for (int i = 0; i < x; i++)
            {
                linia = file.ReadLine();
                if (linia == "") { continue; }
                else
                {                    
                    slowa = linia.Split(' ');
                    konto[i].login = slowa[0];
                    konto[i].haslo = slowa[1];
                    konto[i].typ = slowa[2];
                    konto[i].imie = slowa[3];
                    konto[i].nazwisko = slowa[4];
                    konto[i].email = slowa[5];
                    if (slowa[0]==line_login.Text&&slowa[0]!=""&&slowa[0]!=" ")
                    {
                        MessageBox.Show("Podany login jest zajęty", "Uwaga");
                        wolny = false;
                        break;
                        
                    }
                    else if(slowa[5]==line_email.Text&&slowa[5]!=""&&slowa[5]!=" ")
                    {
                        MessageBox.Show("Istnieje konto z podanym adresem Email", "Uwaga");
                        wolny = false;
                        break;
                    }
                    else if(konto[i].login==Login&&wolny==true)
                    {
                        if (line_login.Text != "")
                        {
                            if (konto[i].login == line_login.Text)
                            {
                                zmiana = false;
                            }
                            else
                            {
                                konto[i].login = line_login.Text;
                                zmiana = true;
                                log = true;
                                nn = i;
                            }
                        }
                        if (line_haslo.Text != "")
                        {
                            if(konto[i].haslo == line_haslo.Text)
                            {
                                
                            }
                            else
                            {
                                konto[i].haslo = line_haslo.Text;
                                zmiana = true;
                            }
                        }
                        if (line_email.Text != "")
                        {
                            if(konto[i].email == line_email.Text)
                            {

                            }
                            else
                            {
                                konto[i].email = line_email.Text;
                                zmiana = true;
                            }
                        }
                    }
                }
            }
            pl.Close();
            pl.Dispose();
            if(zmiana==true&&wolny==true)
            {
                string dane;
                string[] bla;
                bla = new string[x];
                for(int i=0;i<x;i++)
                {
                    dane = konto[i].login + " " + konto[i].haslo + " " + konto[i].typ + " " + konto[i].imie + " " + konto[i].nazwisko + " " + konto[i].email;
                    bla[i] = dane;
                }
                File.WriteAllLines(@"uzytkownicy.txt", bla);
                ///////////////////////////////////////////////aktualizacja wypozyczen////////////////////////////////////////////////
                FileStream lic = new FileStream(@"rents.txt", FileMode.Open, FileAccess.Read);
                StreamReader licz = new StreamReader(lic);
                string lin;
                string[] wyr = new string[7];

                for(int i=0;i<y;i++)
                {
                    lin = licz.ReadLine();
                    if (lin == "") { continue; }
                    else
                    {
                        wyr = lin.Split(' ');
                        wyp[i].loginkl = wyr[0];
                        wyp[i].numersam = Int32.Parse(wyr[1]);
                        wyp[i].poczatek=wyr[2];
                        wyp[i].koniec = wyr[3];
                        if (wyr[4] == "0")
                        {
                            wyp[i].zatwierdzone = false;
                        }
                        else
                        {
                            wyp[i].zatwierdzone = true;
                        }
                        wyp[i].koszt = Int32.Parse(wyr[5]);
                        wyp[i].forma = wyr[6];
                        if(wyp[i].loginkl==Login)
                        {
                            wyp[i].loginkl = konto[nn].login;
                        }
                    }
                }
                lic.Close();
                lic.Dispose();
                string cos,a;
                string[] akt = new string[y];
                for(int i=0;i<y;i++)
                {
                    if (wyp[i].zatwierdzone == false) { a = "0"; }
                    else { a = "1"; }
                    cos = wyp[i].loginkl + " " + wyp[i].numersam + " " + wyp[i].poczatek + " " + wyp[i].koniec + " " + a + " " + wyp[i].koszt + " " + wyp[i].forma;
                    akt[i] = cos;
                }
                File.WriteAllLines(@"rents.txt",akt);

                MessageBox.Show("Wprowadzono zmiany, proszę się ponownie zalogować", "Zmieniono");
                Application.Exit();
                
            }
            else if( zmiana==false)
            {
                MessageBox.Show("Żadne dane nie zostały zmienione", "Zmiana");
                this.Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
