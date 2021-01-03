using System;

namespace _05.Add_And_Subtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstInteger = int.Parse(Console.ReadLine());
            int secondInteger = int.Parse(Console.ReadLine());
            int thirdInteger = int.Parse(Console.ReadLine());

            Console.WriteLine(AddAndSubtract(firstInteger, secondInteger, thirdInteger));
        }

        static int AddAndSubtract(int a, int b, int c)
        {
            int firstCalculation = a + b;
            int secondCalculation = firstCalculation - c;

            return secondCalculation;
        }
    }
}
