using System;

namespace _01.Smallest_Of_Three_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());
            int thirdNum = int.Parse(Console.ReadLine());

            Console.WriteLine(SmallestNumber(firstNum, secondNum, thirdNum));
        }

        static int SmallestNumber(int a, int b, int c)
        {
            int smallest = Math.Min(Math.Min(a, b), c);

            return smallest;
        }
    }
}
