using System;

namespace _10.Multiply_Evens_By_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            Console.WriteLine(GetEvensSumOfNumber(number) * GetOddsSumOfNumber(number));
        }

        static double GetEvensSumOfNumber(double num)
        {
            string absNum = Math.Abs(num).ToString();
            double sum = 0.0;

            for (int i = 0; i < absNum.Length; i++)
            {
                char temp = absNum[i];
                double numericValue = char.GetNumericValue(temp);

                if (temp % 2 == 0)
                {
                    sum += numericValue;
                }
            }

            return sum;
        }

        static double GetOddsSumOfNumber(double num)
        {
            string absNum = Math.Abs(num).ToString();
            double sum = 0.0;

            for (int i = 0; i < absNum.Length; i++)
            {
                char temp = absNum[i];
                double numericValue = char.GetNumericValue(temp);

                if (temp % 2 != 0)
                {
                    sum += numericValue;
                }
            }

            return sum;
        }
    }

}
