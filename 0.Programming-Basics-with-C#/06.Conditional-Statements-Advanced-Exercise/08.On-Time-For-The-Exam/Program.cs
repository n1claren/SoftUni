using System;

namespace OnTime
{
    class Program
    {
        static void Main(string[] args)
        {
            int examHour = int.Parse(Console.ReadLine());
            int examMin = int.Parse(Console.ReadLine());

            int ariveHour = int.Parse(Console.ReadLine());
            int ariveMin = int.Parse(Console.ReadLine());

            int examMinutes = examHour * 60 + examMin;
            int ariveMinutes = ariveHour * 60 + ariveMin;

            if (ariveMinutes == examMinutes)
            {
                Console.WriteLine("On Time");
            }

            else if (ariveMinutes > examMinutes)
            {
                int minafter = ariveMinutes - examMinutes;

                if (minafter < 60)
                {
                    Console.WriteLine("Late");
                    Console.WriteLine($"{minafter} minutes after the start");
                }
                else if (minafter >= 60)
                {
                    int hours = minafter / 60;
                    int minutes = minafter % 60;

                    if (minutes < 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:0{minutes} hours after the start");
                    }

                    else if (minutes == 0)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:00 hours after the start");
                    }

                    else if (minutes >= 10)
                    {
                        Console.WriteLine("Late");
                        Console.WriteLine($"{hours}:{minutes} hours after the start");
                    }
                }
            }

            else if (ariveMinutes < examMinutes)
            {
                int timebefore = examMinutes - ariveMinutes;

                if (timebefore <= 30)
                {
                    Console.WriteLine("On Time");
                    Console.WriteLine($"{timebefore} minutes before the start");
                }

                else if (timebefore > 30)
                {
                    if (timebefore >= 60)
                    {
                        int hours = timebefore / 60;
                        int minutes = timebefore % 60;

                        if (minutes < 10)
                        {
                            Console.WriteLine("Early");
                            Console.WriteLine($"{hours}:0{minutes} hours before the start");
                        }

                        else if (minutes == 0)
                        {
                            Console.WriteLine("Early");
                            Console.WriteLine($"{hours}:00 hours before the start");
                        }

                        else if (minutes >= 10)
                        {
                            Console.WriteLine("Early");
                            Console.WriteLine($"{hours}:{minutes} hours before the start");
                        }
                    }

                    else if (timebefore < 60)
                    {
                        Console.WriteLine("Early");
                        Console.WriteLine($"{timebefore} minutes before the start");
                    }
                }
            }
        }
    }
}
