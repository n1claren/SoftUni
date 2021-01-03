using System;

namespace _10.Top_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                PrintTopNumber(i);
            }
        }

        static void PrintTopNumber(int number)
        {
            int numberDigitSum = 0;
            string stringNum = number.ToString();
            bool isOdd = false;

            for (int i = 0; i <= stringNum.Length - 1; i++)
            {
                int currentDigit = int.Parse(stringNum[i].ToString());
                numberDigitSum += currentDigit;

                if (isOdd == false & currentDigit % 2 != 0)
                {
                    isOdd = true;
                }

            }

            if (numberDigitSum % 8 == 0 & isOdd == true)
            {
                Console.WriteLine(number);
            }

        }
    }
}