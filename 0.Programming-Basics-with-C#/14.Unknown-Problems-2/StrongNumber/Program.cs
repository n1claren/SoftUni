using System;

namespace StrongNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            string num = "";
            num += number;
            int currentDigit = 0;
            int sumFactorial = 0;

            for (int i = 0; i < num.Length; i++)
            {
                currentDigit = number % 10;
                number = (number - currentDigit) / 10;

                int factoriel = 1;

                for (int y = 1; y <= currentDigit; y++)
                {
                    factoriel *= y;
                }

                sumFactorial += factoriel;
            }

            number = int.Parse(num);

            if (number == sumFactorial)
            {
                Console.WriteLine("yes");
            }
            else if (number != sumFactorial)
            {
                Console.WriteLine("no");
            }


        }
    }
}
