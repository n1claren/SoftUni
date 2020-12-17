using System;

namespace IfElseStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            double grade = double.Parse(Console.ReadLine());
            double ExcellentGrade = 5.50;
            if (grade >= ExcellentGrade)
            {
                Console.WriteLine("Excellent!");
            }
        }
    }
}
