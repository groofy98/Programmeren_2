using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LingoLogica
{
    public class LingoLogica
    {
        enum LetterState { Wrong, Correct, WrongPosition }

        LetterState[] EvaluateWord(string playerWord, string lingoWord)
        {
            LetterState[] outcome = new LetterState[lingoWord.Length];
            char[] pWord = playerWord.ToCharArray();
            char[] lWord = lingoWord.ToCharArray();
            for (int x = 0; x < lingoWord.Length; x++)
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

        string ChooseWord(List<string> words)
        {
            Random r = new Random();
            return words[r.Next(0, words.Capacity)];
        }
    }
}
