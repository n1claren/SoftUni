using System;

namespace _01.Day_Of_Week
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] days =
              {
                "Monday",
                "Tuesday",
                "Wednesday",
                "Thursday",
                "Friday",
                "Saturday",
                "Sunday" };

            int dayOfWeek = int.Parse(Console.ReadLine());

            if (dayOfWeek >= 1 && dayOfWeek <= 7)
            {
                Console.WriteLine(days[dayOfWeek - 1]);
            }
            else
            {
                Console.WriteLine("Invalid day!");
            }
        }
    }
}
