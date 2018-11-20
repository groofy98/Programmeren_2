using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_2
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

            Persoon[] personen = new Persoon[3];
            for (int i = 0; i < personen.Length; i++)
            {
                personen[i] = LeesPersoon();
            }
            foreach (Persoon p in personen)
            {
                PrintPersoon(p);
            }
            Console.ReadKey();
        }

        Persoon LeesPersoon()
        {
            Persoon p = new Persoon();
            p.Voornaam = LeesString("Geef voornaam: ");
            p.Achternaam = LeesString("Geef achternaam: ");
            p.Leeftijd = LeesInt("Geef leeftijd: ", 0, 199);
            p.Woonplaats = LeesString("Geef woonplaats: ");
            p.Geslacht = LeesGeslacht("Geef geslacht(m/v)");
            return p;
        }

        void PrintPersoon(Persoon p)
        {
            Console.Write("\n" + p.Voornaam + " ");
            Console.WriteLine(p.Achternaam + " ({0})", p.Geslacht);
            Console.Write("{0} jaar, ", p.Leeftijd);
            Console.WriteLine(p.Woonplaats);
        }

        GeslachtType LeesGeslacht(string vraag)
        {
            string input = LeesString(vraag);
            return input.Equals("m") ? GeslachtType.Man : GeslachtType.Vrouw;
        }

        int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        int LeesInt(string vraag, int min, int max)
        {
            int temp = LeesInt(vraag);
            if (temp > min && temp < max)
                return temp;
            else
                return LeesInt(vraag, min, max);
        }

        string LeesString(string vraag)
        {
            Console.Write(vraag);
            return Console.ReadLine();
        }

    }
}
