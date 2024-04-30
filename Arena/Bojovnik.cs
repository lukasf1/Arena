using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    internal class Bojovnik
    {
        private string jmeno;
        public int maxZivot;
        public int zivot;
        private int utok;
        private int obrana;
        private Kostka kostka;
        private string zprava;

        public Bojovnik(string jmeno, int maxZivot, int utok, int obrana, Kostka kostka)
        {
            this.jmeno = jmeno;
            this.maxZivot = maxZivot;
            this.zivot = maxZivot;
            this.utok = utok;
            this.obrana = obrana;
            this.kostka = kostka;
        }

        public int Utoc(Bojovnik souper)
        {
            int uder = utok + kostka.Hod();
            uder = uder < 0 ? 0 : uder;
            return souper.BranSe(uder);
        }

        public int BranSe(int uder)
        {
            int poskozeni = uder - (obrana + kostka.Hod());
            poskozeni = poskozeni < 0 ? 0 : poskozeni;
            zivot -= poskozeni;
            zivot = zivot < 0 ? 0 : zivot;
            return poskozeni;
        }

        public override string ToString()
        {
            return jmeno;
        }
    }
}
