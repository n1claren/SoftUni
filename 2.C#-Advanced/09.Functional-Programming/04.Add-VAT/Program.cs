using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console
                .ReadLine()
                .Split(", ")
                .Select(decimal.Parse)
                .Select(x => x * 1.2m)
                .ToList()
                .ForEach(x => Console.WriteLine($"{x:F2}"));
        }
    }
}
