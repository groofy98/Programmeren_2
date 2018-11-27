using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_0
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
            int getal = LeesInt("tik een getal: ");
            Console.WriteLine("Je hebt {0} ingetikt.", getal);
            int leeftijd = LeesInt("hoe oud ben je? ", 0, 120);
            Console.WriteLine("Je bent {0} jaar oud.", leeftijd);
            string naam = LeesString("Hoe heet je? ");
            Console.WriteLine("Aangenaam kennis met je te maken, {0}.", naam);
            Console.ReadKey();

        }

        static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        static int LeesInt(string vraag, int min, int max)
        {
            int leeftijd;
            do
            {
                leeftijd = LeesInt(vraag);
            } while (leeftijd < min || leeftijd > max);
            return leeftijd;
        }

        static string LeesString(string vraag)
        {
            Console.WriteLine(vraag);
            return Console.ReadLine();
        }

    }
}
