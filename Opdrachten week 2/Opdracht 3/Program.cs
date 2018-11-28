using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
{
    class Program
    {

        enum RegularCandies { JellyBean, Lozenge, LemonDrop, GumSquare, LollipopHead, JujubeCluster }

        static void Main(string[] args)
        {
            Program myProgram = new Program();
            myProgram.Start();
        }

        void Start()
        {
            RegularCandies[,] speelveld = new RegularCandies[9, 9];
            InitCandies(ref speelveld);
            PrintCandies(speelveld);
            if(ScoreRijAanwezig(speelveld))
                Console.WriteLine("Score rij aanwezig!");
            if (ScoreKolomAanwezig(speelveld))
                Console.WriteLine("Score Kolom aanwezig!");
            Console.ReadKey();
            Start();
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

        bool ScoreRijAanwezig(RegularCandies[,] speelveld)
        {
            int width = speelveld.GetLength(0);
            int height = speelveld.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                int count = 1;
                RegularCandies candy = speelveld[0, i];
                for (int b = 1; b < width; b++)
                {
                    if (candy == speelveld[b, i])
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Rij: {0}", i + 1);
                            return true;
                        }
                        
                           
                        
                    }
                    else count = 1;
                    candy = speelveld[b, i];

                }
            }
            return false;
        }

        bool ScoreKolomAanwezig(RegularCandies[,] speelveld)
        {
            int width = speelveld.GetLength(0);
            int height = speelveld.GetLength(1);
            for (int i = 0; i < width; i++)
            {
                int count = 1;
                RegularCandies candy = speelveld[i, 0];
                for (int b = 1; b < height; b++)
                {
                    if (candy == speelveld[i, b])
                    {
                        count++;
                        if (count == 3)
                        {
                            Console.WriteLine("Kolom: {0}", i + 1);
                            return true;
                        }
                        


                    }
                    else count = 1;
                    candy = speelveld[i, b];

                }
            }
            return false;
        }



    }
}
