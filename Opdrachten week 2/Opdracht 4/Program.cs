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
        }        void MogelijkePaardenSprongen(int[,] schaakbord, Positie positie)
        {
            Positie[] posities = new Positie[8];
            for (int i = 0; i < 8; i++)
            {
                posities[i] = new Positie();
            }
            posities[0].y = 2; posities[0].x = -1;
            posities[1].y = 1; posities[1].x = -2;
            posities[2].y = -1; posities[2].x = -2;
            posities[3].y = -2; posities[3].x = -1;
            posities[4].y = -2; posities[4].x = 1;
            posities[5].y = -1; posities[5].x = 2;
            posities[6].y = 1; posities[6].x = 2;
            posities[7].y = 2; posities[7].x = 1;

            foreach (Positie p in posities)
            {
                try
                {
                    Positie temp = new Positie();
                    temp.x = positie.x + p.x;
                    temp.y = positie.y + p.y;
                    schaakbord[temp.x, temp.y] = 2;
                }
                catch
                {

                }
            }
        }
    }
}