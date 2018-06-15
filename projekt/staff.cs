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
    public partial class staff : Form
    {
        private int x, y, liczba, pomoc;
        private cars[] samo;      
        private wypozyczenie[] tablica;

        

        public staff()
        {
            InitializeComponent();
            x = 0;
            y = 0;
            liczba = 0;
            pomoc = 0;
            FileStream lic = new FileStream(@"cars.txt", FileMode.Open, FileAccess.Read);
            StreamReader licz = new StreamReader(lic);
            while (licz.ReadLine() != null) { x++; }
            lic.Close();
            lic.Dispose();
            samo = new cars[x];
            for(int i=0;i<x;i++)
            {
                samo[i] = new cars();
            }
            FileStream lic2 = new FileStream(@"rents.txt", FileMode.Open, FileAccess.Read);
            StreamReader licz2 = new StreamReader(lic2);
            while (licz2.ReadLine() != null) { y++; }
            lic2.Close();
            lic2.Dispose();
            tablica = new wypozyczenie[y];
            for (int i = 0; i < y; i++)
            {
                tablica[i] = new wypozyczenie();
            }

            FileStream wczyt = new FileStream(@"cars.txt", FileMode.Open, FileAccess.Read);
            StreamReader wczytaj = new StreamReader(wczyt);
            string linia,a1,a2,a3;
            string[] wyrazy = new string[10];
                        
                for (int i = 0; i < x; i++)
                {
                    
                    linia = wczytaj.ReadLine();
                    if (linia == null || linia == "") { continue; i--; }
                    else
                
                    {
                        wyrazy = linia.Split(' ');
                        samo[i].marka = wyrazy[0];
                        samo[i].model = wyrazy[1];
                        samo[i].klasa = wyrazy[2];
                        samo[i].paliwo = wyrazy[3];
                        samo[i].moc = wyrazy[4];
                        samo[i].miejsca = wyrazy[5];
                        a1 = wyrazy[6];
                        a2 = wyrazy[7];
                        a3 = wyrazy[8];
                        samo[i].numer = Int32.Parse(wyrazy[9]);
                        if (a1 == "0")
                        {
                            samo[i].wypozyczony = false;
                        }
                        if (a1 == "1")
                        {
                            samo[i].wypozyczony = true;
                        }
                        if (a2 == "0")
                        {
                            samo[i].klimatyzacja = false;
                        }
                        if (a2 == "1")
                        {
                            samo[i].klimatyzacja = true;
                        }
                        if (a3 == "0")
                        {
                            samo[i].skrzynia = false;
                        }
                        if (a1 == "1")
                        {
                            samo[i].skrzynia = true;
                        }
                    }   
                

                }
            wczyt.Close();
            wczyt.Dispose();
            DataTable tabela = new DataTable();
            tabela.Columns.Add("Numer samochodu");
            tabela.Columns.Add("Marka");
            tabela.Columns.Add("Model");
            tabela.Columns.Add("Klasa");
            tabela.Columns.Add("Rodzaj paliwa");
            tabela.Columns.Add("Moc silnika");
            tabela.Columns.Add("Ilość miejsc");
            tabela.Columns.Add("Dostępność");
            tabela.Columns.Add("Klimatyzacja");
            tabela.Columns.Add("Automatyczna skrzynia biegów");
            string stan, klima, skrzyn;
            for (int i = 0; i < x; i++)
            {
                if (samo[i].marka == "default") { continue; i--; }
                if (samo[i].wypozyczony == false) { stan = "Wolny"; } else { stan = "Zajęty"; }
                if (samo[i].klimatyzacja == false) { klima = "Brak"; } else { klima = "Jest"; }
                if (samo[i].skrzynia == false) { skrzyn = "Brak"; } else { skrzyn = "Jest"; }
                tabela.Rows.Add(samo[i].numer, samo[i].marka, samo[i].model, samo[i].klasa, samo[i].paliwo, samo[i].moc, samo[i].miejsca, stan, klima, skrzyn);
            }
            car.DataSource = tabela;
            FileStream lad = new FileStream(@"rents.txt", FileMode.Open, FileAccess.Read);
            StreamReader laduj = new StreamReader(lad);
            string lin,za;
            string[] wyr = new string[7];
            for(int i=0;i<y;i++)
            {
                lin = laduj.ReadLine();
                if (lin == null || lin == "") { continue; i--; }
                else
                {
                    wyr = lin.Split(' ');
                    tablica[i].loginkl = wyr[0];
                    tablica[i].numersam = Int32.Parse(wyr[1]);
                    tablica[i].poczatek = wyr[2];
                    tablica[i].koniec = wyr[3];
                    za = wyr[4];
                    tablica[i].koszt = Int32.Parse(wyr[5]);
                    tablica[i].forma = wyr[6];
                    if(za=="0")
                    {
                        tablica[i].zatwierdzone = false;
                    }
                    else
                    {
                        tablica[i].zatwierdzone = true;
                    }
                }
            }
            lad.Close();
            lad.Dispose();
            DataTable wypozycz = new DataTable();
            wypozycz.Columns.Add("Login klienta");
            wypozycz.Columns.Add("Numer samochódu");
            wypozycz.Columns.Add("Początek");
            wypozycz.Columns.Add("Koniec");
            wypozycz.Columns.Add("Zatwierdzone");
            wypozycz.Columns.Add("Koszt");
            wypozycz.Columns.Add("Forma płatności");
            
            string stany="Nie";
            for(int i=0;i<y;i++)
            {
                if (tablica[i].numersam == 0 || tablica[i].loginkl == "default") { continue; i--; }
                else
                {
                    if (tablica[i].zatwierdzone == true) { stany = "Tak"; }
                    else { stany = "Nie"; }
                    wypozycz.Rows.Add(tablica[i].loginkl, tablica[i].numersam, tablica[i].poczatek, tablica[i].koniec, stany, tablica[i].koszt, tablica[i].forma);
                }
            }
            
            rents.DataSource = wypozycz;
           




        }

        private void staff_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool istnieje = false;
            liczba = Decimal.ToInt32(numericUpDown1.Value);
            for (int i = 0; i < y; i++)
            {
                if (tablica[i].numersam == liczba)
                { istnieje = true; pomoc = i; }
            }
            if (istnieje == false) { MessageBox.Show("Wybrany numer jest nieprawidłowy", "Uwaga"); }
            else
            {
                string zaa="0";
                tablica[pomoc].zatwierdzone = true;
                string linijka;
                string[] wy = new string[y];
                for (int i = 0; i < y; i++)
                {
                    if (tablica[i].zatwierdzone == false) { zaa = "0"; }
                    else { zaa = "1"; }
                    linijka = tablica[i].loginkl + " " + tablica[i].numersam + " " + tablica[i].poczatek + " " + tablica[i].koniec + " " + zaa + " " + tablica[i].koszt+" "+tablica[i].forma;
                    wy[i] = linijka;
                }
                File.WriteAllLines(@"rents.txt", wy);
                MessageBox.Show("Zatwierdzono", "Uwaga");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool istnieje = false;
            liczba = Decimal.ToInt32(numericUpDown1.Value);
            for (int i = 0; i < y; i++)
            {
                if (tablica[i].numersam == liczba)
                { istnieje = true; pomoc = i;  }
            }
            if (istnieje == false) { MessageBox.Show("Wybrany numer jest nieprawidłowy", "Uwaga"); }
            else
            {
               for(int i=0;i<x;i++)
                {
                    if(samo[i].numer==liczba)
                    {
                        samo[i].wypozyczony = false;
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                string linijka,zaa;
                string[] wy = new string[y];
                for (int i = 0; i < y; i++)
                {
                    if (tablica[i].numersam == liczba) { continue; }
                    else
                    {
                        if (tablica[i].zatwierdzone == false) { zaa = "0"; }
                        else { zaa = "1"; }
                        if (tablica[i].loginkl == "default") { continue; }
                        else
                        {
                            linijka = tablica[i].loginkl + " " + tablica[i].numersam + " " + tablica[i].poczatek + " " + tablica[i].koniec + " " + zaa + " " + tablica[i].koszt + " " + tablica[i].forma;
                            wy[i] = linijka;
                        }
                    }
                }
                File.WriteAllLines(@"rents.txt", wy);
                
                string linijk,wya,kli,sk;
                string[] we = new string[x];
                for (int i=0;i<x;i++)
                {
                    if (samo[i].model == "default") { continue; }
                    else
                    {
                        if (samo[i].wypozyczony == true) { wya = "1"; }
                        else { wya = "0"; }
                        if(samo[i].klimatyzacja==true) { kli = "1"; }
                        else { kli = "0"; }
                        if (samo[i].skrzynia == true) { sk = "1"; }
                        else { sk = "0"; }

                        linijk = samo[i].marka + " " + samo[i].model + " " + samo[i].klasa + " " + samo[i].paliwo + " " + samo[i].moc + " " + samo[i].miejsca+" "+wya+" "+kli+" "+sk+" "+samo[i].numer;
                        we[i] = linijk;

                    }   
                        
                    
                }
                File.WriteAllLines(@"cars.txt", we);
                MessageBox.Show("Usunięto wypożyczenie", "Uwaga");

            }
        }
    }
}
