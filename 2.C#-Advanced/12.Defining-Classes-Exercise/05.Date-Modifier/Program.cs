using System;
using System.Linq;

namespace _05.Date_Modifier
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] startInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            DateTime startDate = new DateTime(startInput[0], startInput[1], startInput[2]);

            int[] endInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            DateTime endDate = new DateTime(endInput[0], endInput[1], endInput[2]);

            DateModifier dateModifier = new DateModifier(startDate, endDate);

            dateModifier.GetTimeBetweenDates();
        }
    }
}
