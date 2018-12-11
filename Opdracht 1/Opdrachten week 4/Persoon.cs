using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdrachten_week_4
{
    class Persoon
    {
        public string naam, woonplaats;
        public int leeftijd;

        Persoon LeesPersoon()
        {
            Persoon p = new Persoon();
            p.naam = LeesString("Wat is uw naam? ");
            p.woonplaats = LeesString("Waar woont u? ");
            p.leeftijd = LeesInt("Wat is is uw leeftijd?");
            return p;
        }

        Persoon LeesPersoon(string n)
        {
            Persoon p = new Persoon();
            p.naam = n;
            p.woonplaats = LeesString("Waar woont u? ");
            p.leeftijd = LeesInt("Wat is is uw leeftijd?");
            return p;
        }

        void ToonPersoon(Persoon p)
        {
            Console.WriteLine("Naam       : {0}", p.naam);
            Console.WriteLine("Woonplaats : {0}", p.woonplaats);
            Console.WriteLine("Leeftijd   : {0}", p.leeftijd);
        }

        void SchrijfPersoon(Persoon p, string bestandsNaam)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\\..\\" + p.naam + ".txt");
            file.WriteLine(p.naam);
            file.WriteLine(p.woonplaats);
            file.WriteLine(p.leeftijd);
        }

        Persoon LeesPersoonBestand(string bestandsNaam)
        {
           
            try
            {
                Persoon p = new Persoon();
                System.IO.StreamReader file =
                    new System.IO.StreamReader(@"..\\..\\" + bestandsNaam + ".txt");
                p.naam = file.ReadLine();
                p.woonplaats = file.ReadLine();
                int.TryParse(file.ReadLine(), out p.leeftijd);
                return p;
            }
            catch {
                return LeesPersoon(bestandsNaam);
            }
            
           
        }

        static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        static string LeesString(string vraag)
        {
            Console.Write(vraag);
            return Console.ReadLine();
        }

    }
}
