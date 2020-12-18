using System;

namespace TrainTheTrainers
{
    class Program
    {
        static void Main(string[] args)
        {
            int jury = int.Parse(Console.ReadLine());

            string input = Console.ReadLine();

            double gradeSum = 0.0;
            double allGradeSum = 0.0;
            double gradeCount = 0;

            while (input != "Finish")
            {
                string presentation = input;

                for (int i = 1; i <= jury; i++)
                {
                    double grade = double.Parse(Console.ReadLine());
                    gradeSum += grade;
                    allGradeSum += grade;
                    gradeCount++;
                }

                Console.WriteLine($"{input} - {gradeSum / jury:F2}.");

                gradeSum = 0;
                input = Console.ReadLine();
            }

            Console.WriteLine($"Student's final assessment is {allGradeSum / gradeCount:F2}.");
        }
    }
}
