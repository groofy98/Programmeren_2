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
            Console.WriteLine(Maand.Februari);
            PrintMaanden();
            PrintMaand(VraagMaand("voer een maand in: "));
            Console.ReadKey();

        }

        int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        int LeesInt(string vraag, int min, int max)
        {
            int temp = LeesInt(vraag);
            if (temp > min && temp < max)
                return temp;
            else
                return LeesInt(vraag, min, max);
        }

        string LeesString(string vraag)
        {
            Console.WriteLine(vraag);
            return Console.ReadLine();
        }

        void PrintMaand(Maand maand)
        {
            Console.WriteLine(maand);
        }

        void PrintMaanden()
        {
            for (Maand m = Maand.Januari; m <= Maand.December; m++)
            {
                Console.Write("{0,2}. ", (int)m + 1);
                PrintMaand(m);
            }
        }

        Maand VraagMaand(string vraag)
        {
            int input = LeesInt(vraag) - 1;
            if (Enum.IsDefined(typeof(Maand), input))
            {
                Console.Write("{0} => ", input + 1);
                return (Maand)input;
            }
            else
            {
                Console.WriteLine("{0} is geen geldige waarde.", input);
                return VraagMaand(vraag);
            }
        }

    }
}
