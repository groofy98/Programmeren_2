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

          
        }
        List<Vak> LeesRapport()
        {
            List<Vak> rapport = new List<Vak>();
            for (int i = 0; i < 3; i++)
            {
                rapport.Add(LeesVak("voer vak in"));
            }
            return rapport;

        }


    }


}
