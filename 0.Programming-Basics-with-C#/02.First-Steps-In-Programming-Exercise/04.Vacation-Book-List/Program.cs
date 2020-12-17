using System;

namespace VacationBookList
{
    class Program
    {
        static void Main(string[] args)
        {
            double pages = double.Parse(Console.ReadLine());
            double PPH = double.Parse(Console.ReadLine());
            double daysToRead = double.Parse(Console.ReadLine());
            double hoursToReadBook = pages / PPH;
            double hoursPerDay = hoursToReadBook / daysToRead;
            Console.WriteLine(hoursPerDay);

        }
    }
}
