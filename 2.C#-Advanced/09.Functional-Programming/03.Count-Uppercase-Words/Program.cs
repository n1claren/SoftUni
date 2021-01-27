using System;
using System.Linq;

namespace _03.Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(word => Char.IsUpper(word[0]))
                .ToList()
                .ForEach(word => Console.WriteLine(word));
                
        }
    }
}
