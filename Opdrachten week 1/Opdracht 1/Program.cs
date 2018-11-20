using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_1
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
            Console.WriteLine(Maand.Januari);
            Console.ReadKey();

        }

        static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        static int LeesInt(string vraag, int min, int max)
        {
            int temp = LeesInt(vraag);
            if (temp > min && temp < max)
                return temp;
            else
                return LeesInt(vraag, min, max);
        }

        static string LeesString(string vraag)
        {
            Console.WriteLine(vraag);
            return Console.ReadLine();
        }

    }
}
