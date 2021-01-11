using System;
using System.Text;
using System.Linq;

namespace _02.Character_Multiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();

            string str1 = input[0];
            string str2 = input[1];

            Console.WriteLine(StringMultiplier(str1, str2));
        }

        static int StringMultiplier(string a, string b)
        {
            int sum = 0;

            for (int i = 0; i < Math.Min(a.Length, b.Length); i++)
            {
                int num1 = a[i];
                int num2 = b[i];

                int num3 = num1 * num2;

                sum += num3;
            }

            for (int i = Math.Min(a.Length, b.Length); i < Math.Max(a.Length, b.Length); i++)
            {
                if (a.Length > b.Length)
                {
                    sum += a[i];
                }
                else
                {
                    sum += b[i];
                }
            }

            return sum;
        }
    }
}
