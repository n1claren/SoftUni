using System;

namespace _09.Spice_Must_Flow
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingYield = int.Parse(Console.ReadLine());

            int daysMined = 0;
            int spice = 0;

            while (startingYield >= 100)
            {
                daysMined++;

                spice += startingYield;

                if (spice >= 26)
                {
                    spice -= 26;
                }
                else
                {
                    spice = 0;
                }

                startingYield -= 10;

            }

            if (spice >= 26)
            {
                spice -= 26;
            }
            else
            {
                spice = 0;
            }

            Console.WriteLine(daysMined);
            Console.WriteLine(spice);
        }
    }
}
