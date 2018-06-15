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
    public partial class add : Form
    {
        private int x = 0;
        private cars nowy;

        public add()
        {
            InitializeComponent();
            FileStream lic = new FileStream(@"cars.txt", FileMode.Open, FileAccess.Read);
            StreamReader licz = new StreamReader(lic);
            while (licz.ReadLine() != null) { x++; }
            lic.Close();
            lic.Dispose();
            nowy = new cars();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            nowy.paliwo = "benzyna";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            nowy.paliwo = "diesel";
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true) { nowy.klimatyzacja = true; }
            else { nowy.klimatyzacja = false; }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true) { nowy.skrzynia = true; }
            else { nowy.skrzynia = false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (marka.Text == ""||comboBox1.SelectedItem==null||nowy.paliwo=="default"||model.Text=="") { MessageBox.Show("Wypełnij wszystkie wymagane pola", "Uwaga"); }
            else
            {
                nowy.marka = marka.Text;
                nowy.model = model.Text;
                nowy.miejsca = miejsca.Value.ToString();
                nowy.moc = moc.Value.ToString();
                nowy.klasa = comboBox1.SelectedItem.ToString();
                nowy.numer = x + 1;
                string a, b, c;
                a = "0";
                if (nowy.klimatyzacja == true) { b = "1"; }
                else { b = "0"; }
                if (nowy.skrzynia == true) { c = "1"; }
                else { c = "0"; }
                string dane = nowy.marka + " " + nowy.model + " " + nowy.klasa + " " + nowy.paliwo + " " + nowy.moc + " " + nowy.miejsca + " " + a + " " + b + " " + c + " " + nowy.numer;
                using (StreamWriter w = File.AppendText(@"cars.txt"))
                {
                    w.WriteLine(dane);
                    w.Dispose();
                    w.Close();
                }
                this.Hide();
            }
        }
    }
}
