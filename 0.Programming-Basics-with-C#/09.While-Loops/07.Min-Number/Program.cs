using System;

namespace MaxNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int minValue = int.MaxValue;

            while (input != "Stop")
            {
                int num = int.Parse(input);

                if (num < minValue)
                {
                    minValue = num;
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(minValue);
        }
    }
}
