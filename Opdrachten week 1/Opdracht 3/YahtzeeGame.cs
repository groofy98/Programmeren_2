using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
{
    class YahtzeeGame
    {
        Dobbelsteen[] dobbelstenen = new Dobbelsteen[5];
        public void Init()
        {
            for (int i = 0; i < dobbelstenen.Length; i++)
                dobbelstenen[i] = new Dobbelsteen();
        }

        public void Gooi()
        {
            foreach (Dobbelsteen d in dobbelstenen)
                d.Gooi();
        }

        public void ToonWorp()
        {
            foreach (Dobbelsteen d in dobbelstenen)
                d.ToonWaarde();
            Console.WriteLine();
        }

        public bool Yahtzee()
        {
            foreach (Dobbelsteen d in dobbelstenen)
            {
                if (d.waarde != dobbelstenen[0].waarde)
                    return false;
            }
            return true;
        }

        public bool ThreeOfAKind()
        {
            if (CountEquals() >= 3)
                return true;
            else return false;
        }


        public int CountEquals()
        {
            int output = 0;
            for (int i = 1; i <= 6; i++)
            {
                int temp = 0;
                foreach (Dobbelsteen d in dobbelstenen)
                {
                    if (d.waarde == i)
                        temp++;
                }
                if (temp > output)
                    output = temp;
            }
            return output;
        }

    }
}
