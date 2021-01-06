using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Messaging
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string text = Console.ReadLine();

            string result = string.Empty;

            List<int> singles = new List<int>();

            for (int i = 0; i < numbers.Count; i++)
            {
                string tempString = numbers[i].ToString();

                int tempNumber = 0;

                for (int z = 0; z < tempString.Length; z++)
                {
                    tempNumber += int.Parse(tempString[z].ToString());
                }

                singles.Add(tempNumber);
            }

            for (int i = 0; i < singles.Count; i++)
            {
                int index = singles[i];

                while (index > text.Length)
                {
                    index -= text.Length;
                }

                result += text[index].ToString();

                text = text.Remove(index, 1);
            }

            Console.WriteLine(result);
        }
    }
}
