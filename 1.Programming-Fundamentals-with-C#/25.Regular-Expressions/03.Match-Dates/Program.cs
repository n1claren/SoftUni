using System;
using System.Text.RegularExpressions;

namespace _03.Match_Dates
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<day>[0-9][0-9])([\/\.-])(?<month>[A-Z]{1}[a-z]{2})(\1)(?<year>[0-9]{4})\b";

            string input = Console.ReadLine();

            MatchCollection matchedDates = Regex.Matches(input, pattern);

            foreach (Match date in matchedDates)
            {
                var day = date.Groups["day"].Value;
                var month = date.Groups["month"].Value;
                var year = date.Groups["year"].Value;

                Console.WriteLine($"Day: {day}, Month: {month}, Year: {year}");
            }
        }
    }
}
