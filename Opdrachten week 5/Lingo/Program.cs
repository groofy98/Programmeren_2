using MyTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lingo
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
            List<string> words = ReadWords();
            string lingoWord = ChooseWord(words);
            PlayLingo(lingoWord);
            Start();
        }

        List<string> ReadWords()
        {
            List<string> l = new List<string>();
            string line;
            System.IO.StreamReader file =
                new System.IO.StreamReader(@"..\\..\\woorden.txt");
            while ((line = file.ReadLine()) != null)
            {
                if (line.Length >= 3)
                    l.Add(line);
            }

            file.Close();

            return l;
        }

        string ChooseWord(List<string> words)
        {
            Random r = new Random();
            return words[r.Next(0, words.Capacity)];
        }

        void PlayLingo(string lingoWord)
        {
            int attempts = 5;
            bool guessed = false;
            do
            {
                string temp = ReadPlayerWord(lingoWord);
                DisplayResult(temp, EvaluateWord(temp, lingoWord));
                if (temp == lingoWord)
                    guessed = true;
                attempts--;
            }
            while (!guessed && attempts > 0);
            if (guessed)
                Console.WriteLine("gefeliciteerd");
            else
                Console.WriteLine("Helaas het woord was {0}", lingoWord);
        }

        int[] EvaluateWord(string playerWord, string lingoWord)
        {
            int[] outcome = new int[lingoWord.Length];
            char[] pWord = playerWord.ToCharArray();
            char[] lWord = lingoWord.ToCharArray();
            for (int x = 0; x< lingoWord.Length; x++)
            {
                if (pWord[x] == lWord[x])
                    outcome[x] = 1;
                else if
                    (lWord.Contains(pWord[x]))
                    outcome[x] = 2;
                else
                    outcome[x] = 0;
            }
            return outcome;
        }

        void DisplayResult (string playerWord, int[] result)
        {
            char[] pWord = playerWord.ToCharArray();
            for(int i = 0; i < pWord.Length; i++)
            {
                
                switch (result[i])
                {
                    case 1:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case 2:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case 0:
                        break;
                    default:
                        break;                    
                }
                Console.Write(pWord[i]);
                Console.ResetColor();
            }
            Console.WriteLine();


        }

        string ReadPlayerWord(string word)
        {
            string temp;
            temp = LeesTools.LeesString("Voer een woord in van " + word.Length + " letters: " );
            if (temp.Length == word.Length)
                return temp;
            else
                return ReadPlayerWord(word);
        }
    }
}
