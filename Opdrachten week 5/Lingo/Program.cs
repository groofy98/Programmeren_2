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
        enum LetterState {Wrong, Correct, WrongPosition}

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

        LetterState[] EvaluateWord(string playerWord, string lingoWord)
        {
            LetterState[] outcome = new LetterState[lingoWord.Length];
            char[] pWord = playerWord.ToCharArray();
            char[] lWord = lingoWord.ToCharArray();
            for (int x = 0; x< lingoWord.Length; x++)
            {
                if (pWord[x] == lWord[x])
                    outcome[x] = LetterState.Correct;
                else if
                    (lWord.Contains(pWord[x]))
                    outcome[x] = LetterState.WrongPosition;
                else
                    outcome[x] = LetterState.Wrong;
            }
            return outcome;
        }

        void DisplayResult (string playerWord, LetterState[] result)
        {
            char[] pWord = playerWord.ToCharArray();
            for(int i = 0; i < pWord.Length; i++)
            {
                
                switch (result[i])
                {
                    case LetterState.Correct:
                        Console.BackgroundColor = ConsoleColor.Green;
                        break;
                    case LetterState.WrongPosition:
                        Console.BackgroundColor = ConsoleColor.Red;
                        break;
                    case LetterState.Wrong:
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
