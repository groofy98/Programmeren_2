using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Opdracht_1
{
    class Vak
    {
        public string naam;
        public int cijfer;
        public PraktijkBeoordeling praktijkBeoordeling;
        public enum PraktijkBeoordeling { Geen, Absent, Onvoldoende, Voldoende, Goed };
        PraktijkBeoordeling LeesPraktijkBeoordeling(string vraag)
        {
            return (PraktijkBeoordeling)LeesInt(vraag);
        }
        void ToonPraktijkBeoordeling(PraktijkBeoordeling praktijkBeoordeling)
        {
        }
        public Vak LeesVak(string vraag)
        {
            Vak vak = new Vak();
            vak.naam = LeesString("naam van het vak: ");
            vak.cijfer = LeesInt("Cijfer voor " + vak.naam + ": ");
            vak.praktijkBeoordeling = LeesPraktijkBeoordeling("0. geen 1. absent 2. onvoldoende 3. voldoende 4. goed\n voor praktijkbeoordeling in: ");
            return vak;
        }
        void ToonVak(Vak vak)
        {

        }

        

        static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        static string LeesString(string vraag)
        {
            Console.WriteLine(vraag);
            return Console.ReadLine();
        }
    }
}
