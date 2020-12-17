using System;

namespace Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {
            string year = Console.ReadLine();
            double daysoff = double.Parse(Console.ReadLine());
            double travelweekends = double.Parse(Console.ReadLine());

            double weekends = 48;

            double sofiaWeekends = weekends - travelweekends;
            double freeSofiaWeekends = sofiaWeekends * 3 / 4;

            double daysOffGame = daysoff * 2 / 3;

            double totalGames = freeSofiaWeekends + travelweekends + daysOffGame;


            if (year == "leap")
            {
                totalGames = totalGames + totalGames * 0.15;
                Console.WriteLine(Math.Floor(totalGames));
            }
            else if (year == "normal")
            {
                Console.WriteLine(Math.Floor(totalGames));
            }
        }
    }
}
