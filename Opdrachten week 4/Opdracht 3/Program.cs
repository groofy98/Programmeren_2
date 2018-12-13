using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
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
            Console.WriteLine("\nAantal berichten gevonden: {0}", ZoekWoordInBestand("..\\..\\trump.txt", LeesString("Welk woord wil je zoeken?: ")));

            Start();
        }


        bool ZitWoordInRegel(string regel, string woord)
        {
            bool boo = false;
            if (regel.ToUpper().Contains(woord.ToUpper()))
                boo = true;
            return boo;
        }

        void ToonWoordInRegel(string regel, string woord)
        {            
            int index = regel.ToUpper().IndexOf(woord.ToUpper());
            Console.Write(regel.Substring(0, index));
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(regel.Substring(index, woord.Length));
            Console.ResetColor();
            if (ZitWoordInRegel(regel.Substring(index + woord.Length), woord))
                ToonWoordInRegel(regel.Substring(index + woord.Length), woord);
            else
                Console.WriteLine(regel.Substring(index + woord.Length));            
        }

        int ZoekWoordInBestand(string bestandsnaam, string woord)
        {
            int temp = 0;
            string line;
            StreamReader file = new StreamReader(@"..\\..\\trump.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (ZitWoordInRegel(line, woord))
                {
                    Console.WriteLine();
                    ToonWoordInRegel(line, woord);
                    temp++;
                }

            }
            return temp;
        }

        static string LeesString(string vraag)
        {
            Console.Write(vraag);
            return Console.ReadLine();
        }
    }
}
