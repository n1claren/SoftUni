using System;
using System.Linq;

namespace _04.Froggy
{
    class Program
    {
        static void Main(string[] args)
        {
            Lake lake = new Lake(Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray());

            Console.WriteLine(String.Join(", ", lake));
        }
    }
}
