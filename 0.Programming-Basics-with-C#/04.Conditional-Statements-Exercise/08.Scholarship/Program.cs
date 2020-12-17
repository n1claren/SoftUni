using System;

namespace Scholarship2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double income = double.Parse(Console.ReadLine());
            double avgGrade = double.Parse(Console.ReadLine());
            double minIncome = double.Parse(Console.ReadLine());

            double scholarship = 0.0;

            if (avgGrade >= 5.5)
            {
                scholarship = avgGrade * 25;
                Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");

            }

            else if (income < minIncome && avgGrade >= 4.5)
            {
                scholarship = minIncome * 0.35;
                Console.WriteLine($"You get a Social scholarship {Math.Floor(scholarship)} BGN");
            }

            else if (avgGrade >= 5.5 && income < minIncome)
            {
                if (minIncome * 0.35 == avgGrade * 25)
                {
                    scholarship = avgGrade * 25;
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                }
                else if (minIncome * 0.35 > avgGrade * 25)
                {
                    scholarship = minIncome * 0.35;
                    Console.WriteLine($"You get a Social scholarship {Math.Floor(scholarship)} BGN");
                }
                
                else if (minIncome * 0.35 < avgGrade * 25)
                {
                    scholarship = avgGrade * 25;
                    Console.WriteLine($"You get a scholarship for excellent results {Math.Floor(scholarship)} BGN");
                }
            }
            else
            {
                Console.WriteLine("You cannot get a scholarship!");
            }

        }
    }
}
