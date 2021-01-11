using System;
using System.Text;

namespace _07.String_Explosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            int power = 0;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    sb.Append(currentChar);
                }
                else if (power == 0)
                {
                    sb.Append(currentChar);
                }
                else
                {
                    power--;
                }
            }

            Console.WriteLine(sb);
        }
    }
}
