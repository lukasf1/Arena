using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    internal class Kostka
    {
        private Random random;
        private int pocetSten;
        
        public Kostka() 
        {
            pocetSten = 6;
            random = new Random();
        }

        public Kostka(int pocetSten)
        {
            this.pocetSten = pocetSten;
            random = new Random();
        }

        public int VratPocetSten() 
        {
            return pocetSten;
        }

        public int Hod() 
        {
            int hod = random.Next(pocetSten * 2) + 1;
            if (hod > pocetSten)
            {
                return hod - pocetSten;
            } else
            {
                return hod * (-1);
            }
        }

        public int HodKladne()
        {
            int hod = random.Next(pocetSten) + 1;
            return hod;
        }

        public override string ToString()
        {
            return $"Kostka s {pocetSten} stěnami";
        }
    }
}
