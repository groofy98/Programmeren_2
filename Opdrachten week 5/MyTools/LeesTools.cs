using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTools
{
    public class LeesTools
    {
        public static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        public static int LeesInt(string vraag, int min, int max)
        {
            int leeftijd;
            do
            {
                leeftijd = LeesInt(vraag);
            } while (leeftijd < min || leeftijd > max);
            return leeftijd;
        }

        public static string LeesString(string vraag)
        {
            Console.WriteLine(vraag);
            return Console.ReadLine();
        }
    }
}
