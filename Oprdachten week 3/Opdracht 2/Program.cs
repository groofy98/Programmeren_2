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
            List<string> woordenLijst = WoordenLijst();
            GalgjeSpel galgje = new GalgjeSpel();
            galgje.Init(SelecteerWoord(woordenLijst));
            Console.WriteLine(SpeelGalgje(galgje) ? "Je hebt gewonnen!" : ("Helaas je hebt verloren het woord was: {0}"), galgje.geheimWoord);
            Console.ReadKey();
            Start();
        }

        bool SpeelGalgje(GalgjeSpel galgje)
        {
            int pogingen = 8;
            //ToonWoord(galgje.geheimWoord);
            ToonWoord(galgje.geradenWoord);
            do
            {
                char temp = LeesLetter(galgje.ingevoerdeLetters);
                galgje.ingevoerdeLetters.Add(temp);
                if (!galgje.RaadLetter(temp))
                    pogingen--;
                ToonLetters(galgje.ingevoerdeLetters);
                ToonWoord(galgje.geradenWoord);
                Console.WriteLine("Aantal pogingen over: {0}\n", pogingen);
            } while (!galgje.IsGeraden() && pogingen != 0);
            return galgje.IsGeraden();
        }

        void ToonWoord(string woord)
        {
            Console.WriteLine();
            char[] chars = woord.ToCharArray();
            foreach (char c in chars)
            {
                Console.Write(c + " ");
            }
            Console.WriteLine("\n");
        }

        void ToonLetters(List<char> letters)
        {
            string temp = "";
            foreach (char c in letters)
                temp += (c + " ");
            Console.WriteLine("ingevoerde letters: " + temp);

        }

        char LeesLetter(List<char> verbodenLetters)
        {
            char letter;
            do
            {
                Console.Write("Geef een letter: ");
                letter = char.Parse(Console.ReadLine());

            } while (verbodenLetters.Contains(letter));
            return letter;
        }



        string SelecteerWoord(List<string> woorden)
        {
            Random r = new Random();
            return woorden[r.Next(0, woorden.Count - 1)];
        }

        List<string> WoordenLijst()
        {
            List<string> l = new List<string>();
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"..\\..\\woorden.txt");
            while ((line = file.ReadLine()) != null)
            {   
                if (line.Length >= 3 )
                    l.Add(line);
            }

            file.Close();

            return l;
        }
    }
}
