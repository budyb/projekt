using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace projekt
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dodajKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel_kont panel = new panel_kont();
            panel.ShowDialog();
        }

        private void edytujKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            edycja edytuj = new edycja();
            edytuj.ShowDialog();
        }

        private void dodajSamochódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            add dodaj = new add();
            dodaj.ShowDialog();
        }

        private void usuńKontoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usuwanie usun = new usuwanie();
            usun.ShowDialog();
        }
    }
}
