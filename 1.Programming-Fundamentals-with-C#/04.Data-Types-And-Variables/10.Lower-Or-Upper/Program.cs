using System;

namespace _10.Lower_Or_Upper
{
    class Program
    {
        static void Main(string[] args)
        {
            char input = char.Parse(Console.ReadLine());

            if ((int)input >= 65 && (int)input <= 90)
            {
                Console.WriteLine("upper-case");
            }

            else if ((int)input >= 97 && (int)input <= 122)
            {
                Console.WriteLine("lower-case");
            }
        }
    }
}
