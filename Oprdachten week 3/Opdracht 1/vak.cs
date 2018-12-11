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
            Console.WriteLine(praktijkBeoordeling);
        }

        public Vak LeesVak(string vraag)
        {   
            Console.WriteLine(vraag);
            naam = LeesString("Naam van het vak: ");
            cijfer = LeesInt("Cijfer voor " + naam + ": ");
            praktijkBeoordeling = LeesPraktijkBeoordeling(("0. geen 1. absent 2. onvoldoende 3. voldoende 4. goed\nPracticum beoordeling voor " + naam + ": " ));
            Console.WriteLine();
            return this;
        }
        public void ToonVak(Vak vak)
        {
            Console.Write("{0:000}      : {1}  ", vak.naam, vak.cijfer);
            vak.ToonPraktijkBeoordeling(vak.praktijkBeoordeling);
        }

        public bool IsBehaald()
        {
            bool b = false;
            if(praktijkBeoordeling == PraktijkBeoordeling.Goed || praktijkBeoordeling == PraktijkBeoordeling.Voldoende)
            {
                if (cijfer >= 55)
                    b = true;
            }
            return b;
        }

        public bool IsCumLaude()
        {
            bool b = false;
            if (praktijkBeoordeling == PraktijkBeoordeling.Goed && cijfer >= 80)
                b = true;
            return b;
        }



        static int LeesInt(string vraag)
        {
            Console.Write(vraag);
            return int.Parse(Console.ReadLine());
        }

        static string LeesString(string vraag)
        {
            Console.Write(vraag);
            return Console.ReadLine();
        }
    }
}
