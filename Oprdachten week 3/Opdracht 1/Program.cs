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
            
            ToonRapport(LeesRapport());
            Console.ReadKey();
        }
        List<Vak> LeesRapport()
        {
            List<Vak> rapport = new List<Vak>();
            for (int i = 0; i < 3; i++)
            {
                Vak vak = new Vak();
                rapport.Add(vak.LeesVak("Voer een vak in."));
            }
            return rapport;

        }

        void ToonRapport(List<Vak> rapport)
        {
            bool cumlaude = true;
            bool geslaagd = true;
            int herkansingen = 0;

            foreach(Vak v in rapport)
            {
                v.ToonVak(v);
            }

            foreach (Vak v in rapport)
            {
                if (cumlaude)
                {
                    if (!v.IsCumLaude())
                        cumlaude = false;
                }

                if (!v.IsBehaald())
                {
                    geslaagd = false;
                    herkansingen++;
                }
            }

            if (cumlaude)
                Console.WriteLine("Gefeliciteerd!, je bent cum laude geslaagd! ");
            else if (geslaagd)
                Console.WriteLine("Gefeliciteerd!, je bent geslaagd!");
            else
                Console.WriteLine("HELAAS, je bent gezakt en hebt {0} herkansingen", herkansingen);
        }


    }


}
