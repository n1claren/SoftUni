using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            Dictionary<string, string> reversedInputs = new Dictionary<string, string>();

            while (input != "end")
            {
                string reverse = new string(input.Reverse().ToArray());

                reversedInputs.Add(input, reverse);

                input = Console.ReadLine();
            }

            foreach (var inputs in reversedInputs)
            {
                Console.WriteLine($"{inputs.Key} = {inputs.Value}");
            }


        }
    }
}