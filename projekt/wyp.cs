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
    public partial class wyp : Form
    {
        private wypozyczenie nowe;
        private cars[] aktualizacja;
        

        public wyp(string login, int numer2, string klasy, int x)
        {
            InitializeComponent();
            Login = login;
            Numer2 = numer2;
            Klasy = klasy;
            Y = x;
            aktualizacja = new cars[Y];
            for(int i = 0; i < Y; i++) { aktualizacja[i] = new cars(); }
            nowe = new wypozyczenie();
            
        }

        public string Login { get; }
        public int Numer2 { get; }
        public string Klasy { get; }
        public int Y { get; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        

        private void poczatek_DateSelected(object sender, DateRangeEventArgs e)
        {
            
            nowe.poczatek = poczatek.SelectionRange.Start.ToShortDateString();
            
        }

        private void koniec_DateSelected(object sender, DateRangeEventArgs e)
        {
            nowe.koniec = koniec.SelectionRange.Start.ToShortDateString();

        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            nowe.forma = "card";
        }

        private void radioButton2_Click(object sender, EventArgs e)
        {
            nowe.forma = "money";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (nowe.poczatek == "default" || nowe.koniec == "default" || nowe.forma == "default")
            {
                MessageBox.Show("Upewnij się że wypełniłeś wszystkie pola", "Uwaga");
            }
            else
            {
                int dni = (koniec.SelectionRange.Start - poczatek.SelectionRange.Start).Days;
                if(dni<2)
                {
                    MessageBox.Show("Musisz wypożyczyć samochód na minimum dwa dni", "Uwaga");
                }
                else if(dni>100)
                {
                    MessageBox.Show("Maksymalny okres wypozyczenia to 100 dni","Uwaga");
                }
                else if (poczatek.SelectionRange.Start<DateTime.Today)
                {
                    MessageBox.Show("Wybierz poprawną datę początku!", "Błąd");
                }
                else
                {
                    if(Klasy=="A")
                    {
                        nowe.koszt = dni * 85;
                    }
                    else if(Klasy=="B")
                    {
                        nowe.koszt = dni * 100;
                    }
                    else if(Klasy=="C")
                    {
                        nowe.koszt = dni * 150;
                    }
                    else if(Klasy=="D")
                    {
                        nowe.koszt = dni * 200;
                    }
                    nowe.loginkl = Login;
                    nowe.numersam = Numer2;
                    string dane = nowe.loginkl + " " + nowe.numersam + " " + nowe.poczatek + " " + nowe.koniec + " " + '0' + " " + nowe.koszt + " " + nowe.forma;
                    using (StreamWriter w = File.AppendText(@"rents.txt"))
                    {
                        w.WriteLine(dane);
                        w.Dispose();
                        w.Close();
                    }
                    int miejsce = 0;
                    FileStream lic = new FileStream(@"cars.txt", FileMode.Open, FileAccess.Read);
                    StreamReader licz = new StreamReader(lic);
                    string linia;
                    string[] slowa;
                    slowa = new string[10];
                    string a1, a2, a3, a4;
                    for (int i=0;i<Y;i++)
                    {
                        linia = licz.ReadLine();
                        if (linia == "") { continue; }
                        else
                        {
                            slowa = linia.Split(' ');
                            aktualizacja[i].marka = slowa[0];
                            aktualizacja[i].model = slowa[1];
                            aktualizacja[i].klasa = slowa[2];
                            aktualizacja[i].paliwo = slowa[3];
                            aktualizacja[i].moc = slowa[4];
                            aktualizacja[i].miejsca = slowa[5];
                            a1 = slowa[6];
                            a2 = slowa[7];
                            a3 = slowa[8];
                            a4 = slowa[9];
                            if (a1 == "0")
                            {
                                aktualizacja[i].wypozyczony = false;
                            }
                            if (a1 == "1")
                            {
                                aktualizacja[i].wypozyczony = true;
                            }
                            if (a2 == "0")
                            {
                                aktualizacja[i].klimatyzacja = false;
                            }
                            if (a2 == "1")
                            {
                                aktualizacja[i].klimatyzacja = true;
                            }
                            if (a3 == "0")
                            {
                                aktualizacja[i].skrzynia = false;
                            }
                            if (a1 == "1")
                            {
                                aktualizacja[i].skrzynia = true;
                            }
                            aktualizacja[i].numer = Int32.Parse(a4);
                            if(aktualizacja[i].numer==nowe.numersam)
                            {
                                miejsce = i;
                            }
                        }
                    }
                    lic.Close();
                    lic.Dispose();
                    aktualizacja[miejsce].wypozyczony = true;
                    string now;
                    string[] auta;
                    auta = new string[Y];
                    string a, b, c;
                    for(int i=0;i<Y;i++)
                    {
                        if (aktualizacja[i].wypozyczony == false) { a = "0"; }
                        else { a = "1"; }
                        if (aktualizacja[i].klimatyzacja == false) { b = "0"; }
                        else { b = "1"; }
                        if(aktualizacja[i].skrzynia==false) { c = "0"; }
                        else { c = "1"; }
                        now = aktualizacja[i].marka + " " + aktualizacja[i].model + " " + aktualizacja[i].klasa + " " + aktualizacja[i].paliwo + " " + aktualizacja[i].moc + " " + aktualizacja[i].miejsca + " " + a + " " + b + " " + c + " " + aktualizacja[i].numer;
                        auta[i] = now;
                    }
                    System.IO.File.WriteAllLines(@"cars.txt", auta);
                    MessageBox.Show("Wypożyczono samochód", "Wypożyczono");
                    this.Close();
                    Show();
                }
            }
        }
    }
}
