using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CandyCrushLogica.Class1;

namespace CandyCrush
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
            RegularCandies[,] speelveld;

            try
            {
                speelveld = LeesSpeelveld("speelvelden");
                SchrijfSpeelveld(speelveld, "speelvelden");
            }
            catch
            {
                Console.WriteLine("Nieuw speelveld wordt aangemaakt");
                speelveld = new RegularCandies[9, 9];
                InitCandies(ref speelveld);
                SchrijfSpeelveld(speelveld, "speelvelden");
            }
            PrintCandies(speelveld);
            if (ScoreRijAanwezig(speelveld))
                Console.WriteLine("Score rij aanwezig!");
            if (ScoreKolomAanwezig(speelveld))
                Console.WriteLine("Score Kolom aanwezig!");
            Console.ReadKey();
            Start();
        }

        void SchrijfSpeelveld(RegularCandies[,] speelveld, string bestandsnaam)
        {
            System.IO.StreamWriter file = new System.IO.StreamWriter(@"..\\..\\" + bestandsnaam + ".txt");
            try
            {
                file.WriteLine(speelveld.GetLength(0));
                file.WriteLine(speelveld.GetLength(1));
                int width = speelveld.GetLength(0);
                int height = speelveld.GetLength(1);
                for (int i = 0; i < height; i++)
                {
                    string temp = "";
                    for (int b = 0; b < width; b++)
                    {
                        temp += (int)speelveld[b, i] + " ";
                    }
                    file.WriteLine(temp);
                }
                file.Close();

            }
            finally
            {
                file.Close();
            }
        }

        RegularCandies[,] LeesSpeelveld(string bestandsnaam)
        {
            System.IO.StreamReader file = new System.IO.StreamReader(@"..\\..\\" + bestandsnaam + ".txt");
            try
            {
                string[] line;
                RegularCandies[,] speelveld = new RegularCandies[int.Parse(file.ReadLine()), int.Parse(file.ReadLine())];

                for (int i = 0; i < speelveld.GetLength(1); i++)
                {
                    line = file.ReadLine().Split(' ');
                    for (int b = 0; b < speelveld.GetLength(0); b++)
                    {
                        speelveld[b, i] = (RegularCandies)int.Parse(line[b]);
                    }
                }
                file.Close();
                return speelveld;
            }
            finally
            {
                file.Close();

            }


        }

        void InitCandies(ref RegularCandies[,] speelveld)
        {
            Random r = new Random();
            int width = speelveld.GetLength(0);
            int height = speelveld.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    speelveld[b, i] = (RegularCandies)r.Next(0, 6);
                }
            }
        }

        void PrintCandies(RegularCandies[,] speelveld)
        {
            int width = speelveld.GetLength(0);
            int height = speelveld.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    switch (speelveld[b, i])
                    {
                        case RegularCandies.GumSquare:
                            Console.ForegroundColor = ConsoleColor.Green;
                            break;
                        case RegularCandies.JellyBean:
                            Console.ForegroundColor = ConsoleColor.Red;
                            break;
                        case RegularCandies.JujubeCluster:
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case RegularCandies.LemonDrop:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case RegularCandies.LollipopHead:
                            Console.ForegroundColor = ConsoleColor.Blue;
                            break;
                        case RegularCandies.Lozenge:
                            Console.ForegroundColor = ConsoleColor.DarkYellow;
                            break;
                        default:
                            Console.ResetColor();
                            break;
                    }
                    Console.Write("# ");
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Console.WriteLine();
        }

        
    }
}
