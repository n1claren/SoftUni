using System;
using System.Collections.Generic;

namespace _04.Students
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] inputCollection = input.Split(" ");

                string name = inputCollection[0];
                string lastName = inputCollection[1];
                int age = int.Parse(inputCollection[2]);
                string town = inputCollection[3];

                Student student = new Student();

                student.FirstName = name;
                student.LastName = lastName;
                student.Age = age;
                student.Town = town;

                students.Add(student);

                input = Console.ReadLine();
            }

            string studentDisplayTown = Console.ReadLine();

            foreach (var student in students)
            {
                if (student.Town == studentDisplayTown)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
                }
            }
        }
    }

    class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }
    }
}