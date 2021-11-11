using Microsoft.EntityFrameworkCore;
using P03_FootballBetting.Data;

namespace P03_FootballBetting
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            FootballBettingContext dbContext = new FootballBettingContext();

            dbContext.Database.Migrate();

            System.Console.WriteLine("DB created successfully!");
        }
    }
}
