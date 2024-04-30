using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arena
{
    internal class SeznamBojovniku
    {
        private static List<Bojovnik> seznam = new List<Bojovnik>()
            {
                { new Bojovnik("Zalgoren", 240, 12, 3, new Kostka(3)) },
                { new Bojovnik("Shadow", 190, 15, 3, new Kostka(4)) },
                { new Bojovnik("Gandalf", 210, 10, 4, new Kostka(2)) },
            };

        public Bojovnik VyberBojovnikaRandom()
        {
            int pocetSten = seznam.Count;
            Kostka kostka = new Kostka(pocetSten);
            int random = kostka.HodKladne() - 1;
            return seznam[random];
        }

        public static Bojovnik VyberBojovnika()
        {
            int volba;

            while (true)
            {
                try
                {
                    int counter = 0;
                    foreach (Bojovnik i in seznam)
                    {
                        counter++;
                        Console.WriteLine($"{counter} - {i}");
                    }
                    Console.Write("\nZadej cislo bojovnika: ");
                    volba = Convert.ToInt32(Console.ReadLine());
                    if (volba <= 0 || volba > counter) { throw new Exception(); }
                }
                catch
                {
                    Console.WriteLine("Chyba!");
                    Thread.Sleep(325);
                    Console.Clear();
                    continue;
                }
                break;
            }

            Console.Clear();
            return seznam[volba - 1];

        }

        
    }
}
