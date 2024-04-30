using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arena
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bojovnik bojovnik = SeznamBojovniku.VyberBojovnika();
            Souboj souboj = new Souboj(bojovnik);

            souboj.Zacit();


            Console.ReadLine();
        }
    }
}
