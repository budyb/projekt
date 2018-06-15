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
    public partial class user : Form
    {
        private const string Path = @"cars.txt";
        private string klasy;
        private string login;
        private int x;
        private cars[] tab;

        public user(string loign)
        {
            InitializeComponent();
            
            string a1, a2, a3,a4;
            login = loign;
             x = 0;
            string linia;
            string[] wyrazy;
            wyrazy = new string[10];
            FileStream licznik = new FileStream(Path, FileMode.Open, FileAccess.Read);
            StreamReader liczy = new StreamReader(licznik);
            while (liczy.ReadLine() != null) { x++; }
            
            
             tab = new cars[x];
            FileStream wczyt = new FileStream(Path, FileMode.Open, FileAccess.Read);
            StreamReader wczytaj = new StreamReader(wczyt);
            
            while(wczytaj.ReadLine()!=null)
            {
                for(int i=0; i<x;i++)
                {
                    tab[i] = new cars();
                    linia = wczytaj.ReadLine();
                    if (linia != null)
                    {
                        wyrazy = linia.Split(' ');
                        tab[i].marka = wyrazy[0];
                        tab[i].model = wyrazy[1];
                        tab[i].klasa = wyrazy[2];
                        tab[i].paliwo = wyrazy[3];
                        tab[i].moc = wyrazy[4];
                        tab[i].miejsca = wyrazy[5];
                        a1 = wyrazy[6];
                        a2 = wyrazy[7];
                        a3 = wyrazy[8];
                        a4 = wyrazy[9];
                        if (a1 == "0")
                        {
                            tab[i].wypozyczony = false;
                        }
                        if (a1 == "1")
                        {
                            tab[i].wypozyczony = true;
                        }
                        if (a2 == "0")
                        {
                            tab[i].klimatyzacja = false;
                        }
                        if (a2 == "1")
                        {
                            tab[i].klimatyzacja = true;
                        }
                        if (a3 == "0")
                        {
                            tab[i].skrzynia = false;
                        }
                        if (a1 == "1")
                        {
                            tab[i].skrzynia = true;
                        }
                        tab[i].numer = Int32.Parse(a4);
                    }
                }
            }
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
            string stan,klima,skrzyn;
            for (int i = 0; i < x; i++)
            {
                if (tab[i].marka == "default") { continue; }
                if (tab[i].wypozyczony == false) { stan = "Wolny"; } else { stan = "Zajęty"; }
                if (tab[i].klimatyzacja == false) { klima = "Brak"; } else {klima = "Jest"; }
                if(tab[i].skrzynia==false) { skrzyn = "Brak"; } else { skrzyn = "Jest"; }
                tabela.Rows.Add(tab[i].numer, tab[i].marka, tab[i].model, tab[i].klasa, tab[i].paliwo, tab[i].moc, tab[i].miejsca,stan,klima,skrzyn);
            }
            dataGridView1.DataSource = tabela;

    
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int numer2 = Decimal.ToInt32(numericUpDown1.Value);
            if(numer2>x || numer2 < 1)
            {
                MessageBox.Show("Wybrany numer auta jest nieprawidłowy", "Błąd");
            }
            else
            {
                for(int i=0;i<x;i++)
                {
                    if(tab[i].numer==numer2)
                    {
                        if (tab[i].wypozyczony == true)
                        {
                            MessageBox.Show("Wybrany samochód jest zajęty", "Uwaga");
                        }
                        else
                        {
                            klasy = tab[i].klasa;
                            wyp nowy = new wyp(login,numer2,klasy,x);
                            nowy.ShowDialog();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            zarządzanie zarz = new zarządzanie(login);
            zarz.Show();
        }
    }
}
