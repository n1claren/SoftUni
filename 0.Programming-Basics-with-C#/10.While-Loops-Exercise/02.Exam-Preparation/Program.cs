using System;

namespace ExamPreparation
{
    class Program
    {
        static void Main(string[] args)
        {
            int unsatisfyingGradesMax = int.Parse(Console.ReadLine());

            string problem = Console.ReadLine();

            int unsatisfyingGrades = 0;
            bool isGood = true;
            double gradesum = 0;
            int problemCount = 0;
            string lastProblem = "";

            while (problem != "Enough")
            {
                int grade = int.Parse(Console.ReadLine());

                gradesum += grade;
                problemCount++;
                lastProblem = problem;

                if (grade <= 4)
                {
                    unsatisfyingGrades++;

                    if (unsatisfyingGrades == unsatisfyingGradesMax)
                    {
                        isGood = false;
                        break;
                    }
                }

                problem = Console.ReadLine();
            }

            double avgGrade = gradesum / problemCount;

            if (isGood)
            {
                Console.WriteLine($"Average score: {avgGrade:F2}");
                Console.WriteLine($"Number of problems: {problemCount}");
                Console.WriteLine($"Last problem: {lastProblem}");
            }
            else
            {
                Console.WriteLine($"You need a break, {unsatisfyingGrades} poor grades.");
            }
        }
    }
}
