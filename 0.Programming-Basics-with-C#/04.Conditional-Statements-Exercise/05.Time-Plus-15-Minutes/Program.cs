using System;
using System.Runtime.InteropServices.ComTypes;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourInput = int.Parse(Console.ReadLine());
            int minuteInput = int.Parse(Console.ReadLine());

            minuteInput += 15;


            if (minuteInput > 59)
            {

                int houradd = minuteInput / 60;
                int minadd = minuteInput % 60;
                int hourtotal = hourInput + houradd;

                if (hourtotal > 23)
                {
                    hourtotal = 0;
                }

                if (minadd < 10)
                {
                    Console.WriteLine($"{hourtotal}:0{minadd}");
                }
                else
                {
                    Console.WriteLine($"{hourtotal}:{minadd}");
                }
            }
         else
            {
                Console.WriteLine($"{hourInput}:{minuteInput}");
            }
        }
    }
}