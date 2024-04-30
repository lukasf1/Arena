using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arena
{
    internal class Souboj
    {
        private List<Bojovnik> bojovnici = new List<Bojovnik>();
        private int aktivniBojovnikIndex;
        private int braniciBojovnikIndex;
        private Bojovnik aktivniBojovnik;
        private Bojovnik braniciBojovnik;

        public Souboj(Bojovnik bojovnik1)
        {
            SeznamBojovniku seznamBojovniku = new SeznamBojovniku();
            Bojovnik bojovnik2;

            while (true)
            {
                bojovnik2 = seznamBojovniku.VyberBojovnikaRandom();
                if (bojovnik2 != bojovnik1)
                {
                    break;
                }
            }

            bojovnici.Add(bojovnik1);
            bojovnici.Add(bojovnik2);
        }

        public void Zacit()
        {
            Kostka kostka = new Kostka(1);
            aktivniBojovnikIndex = kostka.HodKladne();
            Bojovnik aktivniBojovnik = bojovnici[aktivniBojovnikIndex];

            Console.WriteLine("Vítejte v aréně!");
            Console.WriteLine($"Bojovnící: {bojovnici[0]} a {bojovnici[1]}");
            Console.WriteLine($"\nZačíná bojovník {aktivniBojovnik}");

            Thread.Sleep(2500);

            Run();
        }

        private void VypisStavBojovniku()
        {
            Console.WriteLine($"{bojovnici[0]}");
            VypisHealthBar(bojovnici[0]);
            Console.WriteLine($"{bojovnici[1]}");
            VypisHealthBar(bojovnici[1]);
        }

        private void VypisHealthBar(Bojovnik bojovnik)
        {
            for ( int i = 0; i < bojovnik.zivot / 10; i++ )
            {
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.Write(" ");
            }

            for ( int i = 0; i < bojovnik.maxZivot / 10 - bojovnik.zivot / 10; i++ )
            {
                Console.BackgroundColor = ConsoleColor.Green;
                Console.Write(" ");
            }

            Console.ResetColor();
            Console.WriteLine($" {bojovnik.zivot}");
        }

        private void Konec(Bojovnik vyherce)
        {
            Console.WriteLine("\n************ Konec ************\n");
            Console.WriteLine($"{vyherce} vyhral s {vyherce.zivot} zivoty");
        }

        private void Run()
        {
            while (true)
            {
                braniciBojovnikIndex = aktivniBojovnikIndex;
                aktivniBojovnikIndex = (aktivniBojovnikIndex == 0) ? 1 : 0;
                braniciBojovnik = bojovnici[braniciBojovnikIndex];
                aktivniBojovnik = bojovnici[aktivniBojovnikIndex];
                int poskozeni = aktivniBojovnik.Utoc(braniciBojovnik);

                Console.Clear();
                Console.WriteLine("************ Souboj ************\n");
                Console.WriteLine($"Utoci {aktivniBojovnik} s poskozenim {poskozeni}\n");

                VypisStavBojovniku();

                if (braniciBojovnik.zivot <= 0)
                {
                    Konec(aktivniBojovnik);
                    break;
                }

                Thread.Sleep(750);
            }
        }
    }
}
