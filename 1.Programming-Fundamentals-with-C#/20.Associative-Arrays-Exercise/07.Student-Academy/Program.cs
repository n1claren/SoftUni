using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Student_Academy
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                string student = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(student))
                {
                    students[student].Add(grade);
                }
                else
                {
                    List<double> grades = new List<double>();

                    grades.Add(grade);

                    students.Add(student, grades);
                }
            }

            foreach (var item in students.OrderByDescending(x => x.Value.Average()))
            {
                if (item.Value.Average() >= 4.50)
                {
                    Console.WriteLine($"{item.Key} -> {item.Value.Average():f2}");
                }
            }
        }
    }
}
