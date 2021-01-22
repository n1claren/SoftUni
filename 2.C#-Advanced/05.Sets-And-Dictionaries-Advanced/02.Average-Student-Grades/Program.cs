using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Average_Student_Grades
{
    class Program
    {
        static void Main(string[] args)
        {
            int inputs = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < inputs; i++)
            {
                string[] input = Console.ReadLine().Split();

                string student = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!students.ContainsKey(student))
                {
                    students.Add(student, new List<decimal>());
                }

                students[student].Add(grade);
            }

            foreach (var student in students)
            {
                Console.Write($"{student.Key} -> ");

                foreach (var grade in student.Value)
                {
                    Console.Write($"{grade:F2} ");
                }

                Console.WriteLine($"(avg: {student.Value.Average():F2})");
            }
        }
    }
}
