using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_4
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
            int[,] schaakbord = new int[8, 8];
            InitSchaakbord(schaakbord);
            
            MogelijkePaardenSprongen( schaakbord, PlaatsPaard(schaakbord));
            ToonSchaakbord(schaakbord);
            Console.ReadKey();
            Start();
        }

        void InitSchaakbord(int[,] schaakbord)
        {           
            int width = schaakbord.GetLength(0);
            int height = schaakbord.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    schaakbord[b, i] = 0;
                }
            }
        }

        void ToonSchaakbord(int[,] schaakbord)
        {
            int width = schaakbord.GetLength(0);
            int height = schaakbord.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    switch (schaakbord[b, i])
                    {
                        case 0:
                            Console.Write(". ");
                            break;
                        case 1:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("*");
                            Console.ResetColor();
                            break;
                        case 2:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.Write("*");
                            Console.ResetColor();
                            break;
                        default:
                            break;
                    }                    
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        Positie PlaatsPaard(int[,] schaakbord)
        {
            Random r = new Random();
            Positie p = new Positie();
            p.x = r.Next(0, 7);
            p.y = r.Next(0, 7);
            schaakbord[p.x, p.y] = 1;
            return p;
        }

        void MogelijkePaardenSprongen(int[,] schaakbord, Positie positie)
        {            
            for (int r = -2; r <=  2; r++)
            {
                for (int c = -2; c <= 2; c++)
                {
                    if (Math.Abs(r*c) == 2)
                    {
                        try
                        {
                            schaakbord[(positie.x + c), (positie.y + r)] = 2;
                        }
                        catch { }
                    }
                }
            }
        }

    }
}