using System;
using System.Text.RegularExpressions;

namespace _01.Match_Full_Name
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string regex = @"\b[A-Z]{1}[a-z]+\s[A-Z]{1}[a-z]+\b";

            MatchCollection result = Regex.Matches(input, regex);

            foreach (Match name in result)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}
