using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    class wypozyczenie
    {   public
        string loginkl, poczatek, koniec, forma;
        public
        int numersam;
        public
        bool zatwierdzone;
        public
        int koszt;
        public wypozyczenie()
        {
            loginkl = "default";
            poczatek = "default";
            koniec = "default";
            forma = "default";
            numersam = 0;
            zatwierdzone = false;
            koszt = 0;
        }
    }
}
