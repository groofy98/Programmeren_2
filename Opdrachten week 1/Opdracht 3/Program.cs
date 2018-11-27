using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Opdracht_3
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
            YahtzeeGame yahtzeeGame = new YahtzeeGame();
            yahtzeeGame.Init();
            SpeelYahtzee(yahtzeeGame);

            Console.ReadKey();
        }

        void SpeelYahtzee(YahtzeeGame game)
        {
            int aantalPogingen = 0;
            do
            {
                game.Gooi(); // gooi dobbelstenen
                game.ToonWorp(); // toon worp
                aantalPogingen++;
            } while (!game.Yahtzee() && !game.ThreeOfAKind() && !game.FourOfAKind());
            Console.WriteLine("Aantal pogingen nodig voor {0}: {1}", (game.ThreeOfAKind() ? "Three of a kind" : game.FourOfAKind() ? "Four of a kind" : "Yahtzee"), aantalPogingen);
            Console.ReadKey();
            Start();
        }
    }
}
