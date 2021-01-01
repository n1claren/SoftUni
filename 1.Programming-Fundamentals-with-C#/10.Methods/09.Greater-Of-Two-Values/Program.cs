using System;

namespace _09.Greater_Of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string variable = Console.ReadLine();

            switch (variable)
            {
                case "int":
                    int num1 = int.Parse(Console.ReadLine());
                    int num2 = int.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(num1, num2));
                    break;

                case "char":
                    char char1 = char.Parse(Console.ReadLine());
                    char char2 = char.Parse(Console.ReadLine());
                    Console.WriteLine(GetMax(char1, char2));
                    break;

                case "string":
                    string str1 = Console.ReadLine();
                    string str2 = Console.ReadLine();
                    Console.WriteLine(GetMax(str1, str2));
                    break;
            }

        }

        static int GetMax(int num1, int num2)
        {
            return Math.Max(num1, num2);
        }

        static char GetMax(char char1, char char2)
        {
            return (char)Math.Max(char1, char2);
        }

        static string GetMax(string str1, string str2)
        {
            int comparison = str1.CompareTo(str2);

            if (comparison > 0)
            {
                return str1;
            }

            else
            {
                return str2;
            }
        }
    }

}
