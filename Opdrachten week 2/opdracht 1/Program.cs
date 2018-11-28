using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace opdracht_1
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
            int[,] matrix = new int[3, 7];
            InitMatrix2D(matrix);
            PrintMatrix(matrix);
            Console.WriteLine("\n");
            InitMatrixLineair(matrix);
            PrintMatrixWithCross(matrix);
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


        }

        void InitMatrixLineair(int[,] matrix)
        {            
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            int last = width * height;
            for (int i = 1; i <= last; i++)
            {
                matrix[(i - 1)/height, (i -1)%width] = i;                
            }
        }

        void PrintMatrixWithCross(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            for (int i = 0; i < height; i++)
            {
                for (int b = 0; b < width; b++)
                {
                    if (b == i)
                        Console.ForegroundColor = ConsoleColor.Red;
                    if (b == (height - i - 1))
                        Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.Write("{0,3} ", matrix[b, i]);
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }

    }
}
