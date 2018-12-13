using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            Console.WriteLine("Wat is uw naam? ");
            string temp = Console.ReadLine();
            Persoon p = new Persoon();
            p = p.LeesPersoonBestand(temp);
            p.ToonPersoon(p);
            Console.ReadKey();
            Start();
        }
    }
}
