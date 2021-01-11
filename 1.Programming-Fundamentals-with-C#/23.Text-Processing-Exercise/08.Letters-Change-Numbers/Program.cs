using System;
using System.Collections.Generic;

namespace _08.Letters_Change_Numbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            List<string> separatedInput = new List<string>();

            for (int i = 0; i < input.Length; i++)
            {
                separatedInput.Add(input[i]);
            }

            double sum = 0.0;

            foreach (var line in separatedInput)
            {
                sum += GetLettersAsNumbers(line);
            }

            Console.WriteLine($"{sum:f2}");
        }

        private static double GetLettersAsNumbers(string line)
        {

            char firstLetter = line[0];

            char lastLetter = line[line.Length - 1];

            line = line.Trim(lastLetter);

            line = line.Trim(firstLetter);

            double number = double.Parse(line);

            int firstLetterPosition = GetLetterPositon(firstLetter);

            int lastLetterPosition = GetLetterPositon(lastLetter);

            var sum = 0.0;

            if (char.IsUpper(firstLetter))
            {
                sum = number / firstLetterPosition;
            }
            else
            {
                sum = number * firstLetterPosition;
            }

            if (char.IsUpper(lastLetter))
            {
                sum = sum - lastLetterPosition;
            }
            else
            {
                sum = sum + lastLetterPosition;
            }

            return sum;
        }

        private static int GetLetterPositon(char letter)
        {
            int position = 0;

            if (char.IsUpper(letter))
            {
                position = letter - 'A';
            }

            else
            {
                position = letter - 'a';
            }

            return position + 1;
        }
    }
}
