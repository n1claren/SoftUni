using System;

namespace BonusScore
{
    class Program
    {
        static void Main(string[] args)
        {
            double points = double.Parse(Console.ReadLine());

            if (points <= 100)
            {
                double bonus = 5;
                double pointsbonus1 = points + bonus;
                double even = points % 2;
                double five = points % 5;

                if (even == 0)
                {
                    double totalpoints = pointsbonus1 + 1;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }

                else if (five == 0)
                {
                    double totalpoints = pointsbonus1 + 2;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }

                else
                {
                    double totalpoints = pointsbonus1;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }


            }

            else if (points > 1000)
            {
                double bonus = points * 10 / 100;
                double pointsbonus2 = points + bonus;
                double even = points % 2;
                double five = points % 5;

                if (even == 0)
                {
                    double totalpoints = pointsbonus2 + 1;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }

                else if (five == 0)
                {
                    double totalpoints = pointsbonus2 + 2;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }

                else
                {
                    double totalpoints = pointsbonus2;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }
            }

            else
            {
                double bonus = points * 20 / 100;
                double pointsbonus3 = points + bonus;
                double even = points % 2;
                double five = points % 5;

                if (even == 0)
                {
                    double totalpoints = pointsbonus3 + 1;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }

                else if (five == 0)
                {
                    double totalpoints = pointsbonus3 + 2;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }

                else
                {
                    double totalpoints = pointsbonus3;
                    double bonustotal = totalpoints - points;
                    Console.WriteLine(bonustotal);
                    Console.WriteLine(totalpoints);
                }
            }
        }
    }
}
