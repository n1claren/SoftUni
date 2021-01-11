using System;
using System.Text;

namespace _05.Multiply_Big_Number
{
    class Program
    {
        static void Main(string[] args)
        {
            string num1 = Console.ReadLine().TrimStart('0');
            int num2 = int.Parse(Console.ReadLine());

            if (num2 == 0 || num1 == "")
            {
                Console.WriteLine(0);
                return;
            }

            int remainder = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = num1.Length - 1; i >= 0; i--)
            {
                int currentResult = int.Parse(num1[i].ToString()) * num2 + remainder;
                remainder = 0;

                if (currentResult > 9)
                {
                    remainder = currentResult / 10;
                    currentResult = currentResult % 10;
                }

                sb.Append(currentResult);
            }

            if (remainder != 0)
            {
                sb.Append(remainder);
            }

            StringBuilder bs = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                bs.Append(sb[i]);
            }

            Console.WriteLine(bs);
        }
    }
}
