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
            int[,] matrix = new int[11, 11];
            InitMatrix2D(matrix);
            PrintMatrix(matrix);
            InitMatrixRandom(matrix, 1, 20);
            PrintMatrix(matrix);
            int temp = LeesInt("vul een getal in tussen 1 en 20: ");
            Console.WriteLine("Eerste keer dat getal voor komt: ");
            PrintPositie(ZoekGetal(matrix, temp));
            Console.WriteLine("laatste keer dat getal voor komt");
            PrintPositie(ZoekGetalAchterwaarts(matrix, temp));
            Console.WriteLine("\n");
            Console.ReadKey();
        }

        void InitMatrix2D(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    matrix[b, i] = b + 1 + i * width;
                }
            }

        }

        void PrintMatrix(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    Console.Write("{0,3} ", matrix[b, i]);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        void InitMatrixRandom(int[,] matrix, int min, int max)
        {
            Random r = new Random();
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    matrix[b, i] = r.Next(min, max);
                }
            }

        }

        Positie ZoekGetal(int[,] matrix, int zoekGetal)
        {
            Positie p = new Positie();
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                   if (matrix[b, i] == zoekGetal)
                    {
                        
                        p.Rij = i;
                        p.Kolom = b;
                        return p;
                    }
                       
                }
            }
            return p;
        }

        Positie ZoekGetalAchterwaarts(int[,] matrix, int zoekGetal)
        {
            Positie p = new Positie();
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = height -1; i >= 0 ; i--)
            {
                for (int b = width -1; b >= 0; b--)
                {
                    if (matrix[b, i] == zoekGetal)
                    {

                        p.Rij = i;
                        p.Kolom = b;
                        return p;
                    }

                }
            }
            return p;
        }


        static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        void PrintPositie(Positie p)
        {
            Console.WriteLine("Kolom: {0}\nRij: {1}\n",p.Kolom + 1,p.Rij + 1);
        }
    }
}
