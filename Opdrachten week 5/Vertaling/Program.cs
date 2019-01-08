using MyTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vertaling
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
            TranslateWords(ReadWords("niks"));
        }


        Dictionary<string, string> ReadWords(string filename)
        {
            string line;
            string[] lines = new string[2];
            Dictionary<string, string> woordenBoek = new Dictionary<string, string>();
            StreamReader file = new StreamReader(@"..\\..\\dictionary.csv");
            while ((line = file.ReadLine()) != null)
            {
                lines = line.Split(';');
                woordenBoek.Add(lines[0], lines[1]);
            }
            return woordenBoek;
        }

        void TranslateWords(Dictionary<string, string> words)
        {
            string temp = LeesTools.LeesString("Enter a word: ");
            if (temp == "stop")
                return;
            if (temp == "listall")
            {
                ListAllWords(words);
            }
            else if (words.ContainsKey(temp))
            {
                Console.WriteLine("{0} => {1}", temp, words[temp]);
            }
            else
                Console.WriteLine("Woord niet gevonden");
            TranslateWords(words);
        }

        void ListAllWords(Dictionary<string, string> words)
        {
            foreach (KeyValuePair<string, string> w in words)
            {
                Console.WriteLine("{0} => {1}", w.Key, w.Value);
            }
        }
    }
}
