using System;

namespace _07.Repeat_String
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            int reps = int.Parse(Console.ReadLine());

            Console.WriteLine(StringRepeater(str, reps));
        }

        static string StringRepeater(string str, int reps)
        {
            string temp = "";

            for (int i = 0; i < reps; i++)
            {
                temp += str;
            }

            return temp;
        }
    }
}
