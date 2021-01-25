using System;
using System.IO;
using System.Linq;

namespace _02.Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");

            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];

                int letters = CountOfLetters(line);
                int punctuations = CountOfPunctuation(line);

                result[i] = $"Line {i + 1}:{lines[i]}({letters})({punctuations})";
            }

            File.WriteAllLines("../../../output.txt", result);
        }

        static int CountOfLetters(string line)
        {
            int counter = 0;

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (Char.IsLetter(currentChar))
                {
                    counter++;
                }
            }

            return counter;
        }

        static int CountOfPunctuation(string line)
        {
            int counter = 0;

            char[] punctuationSymbols = new char[] { '\'', '-', ',', '.', '!', '?', ';', };

            for (int i = 0; i < line.Length; i++)
            {
                char currentChar = line[i];

                if (punctuationSymbols.Contains(currentChar))
                {
                    counter++;
                }
            }

            return counter;
        }
    }
}
