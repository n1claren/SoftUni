using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            int player1time = int.Parse(Console.ReadLine());
            int player2time = int.Parse(Console.ReadLine());
            int player3time = int.Parse(Console.ReadLine());

            int totaltime = player1time + player2time + player3time;
            int minutes = totaltime / 60;
            int seconds = totaltime % 60;

            if (seconds < 10)
            {
                Console.WriteLine($"{minutes}:0{seconds}");

            }
            else
            {
                Console.WriteLine($"{minutes}:{seconds}");
            }
        }
    }
}
