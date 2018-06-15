using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projekt
{
    class cars
    {   public
        String marka, model, klasa, paliwo, moc, miejsca;
        public
        bool wypozyczony, klimatyzacja, skrzynia;
        public
        int numer;
        public cars()
        {
            wypozyczony = false;
            klimatyzacja = false;
            skrzynia = false;
            marka = "default";
            model = "default";
            klasa = "default";
            paliwo = "default";
            moc = "default";
            miejsca = "default";
            numer = 0;

        }
    }
}
