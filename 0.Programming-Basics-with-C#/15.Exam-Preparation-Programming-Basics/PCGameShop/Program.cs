using System;

namespace PCGameShop
{
    class Program
    {
        static void Main(string[] args)
        {
            int gamesSold = int.Parse(Console.ReadLine());
            string gameTitle = "";
            double HearthstoneCopies = 0;
            double FortniteCopies = 0;
            double OverwatchCopies = 0;
            double OtherGameCopies = 0;

            for (int i = 1; i <= gamesSold; i++)
            {
                gameTitle = Console.ReadLine();

                switch (gameTitle)
                {
                    case "Hearthstone":
                        HearthstoneCopies += 1;
                        break;
                    case "Fortnite":
                        FortniteCopies += 1;
                        break;
                    case "Overwatch":
                        OverwatchCopies += 1;
                        break;
                    default:
                        OtherGameCopies += 1;
                        break;
                }
            }

            double HeartstonePercentage = HearthstoneCopies / gamesSold * 100;
            double FortnitePercentage = FortniteCopies / gamesSold * 100;
            double OverwatchPercentage = OverwatchCopies / gamesSold * 100;
            double OtherGamesPercentage = OtherGameCopies / gamesSold * 100;

            Console.WriteLine($"Hearthstone - {HeartstonePercentage:f2}%");
            Console.WriteLine($"Fornite - {FortnitePercentage:f2}%");
            Console.WriteLine($"Overwatch - {OverwatchPercentage:F2}%");
            Console.WriteLine($"Others - {OtherGamesPercentage}%");
        }
    }
}
