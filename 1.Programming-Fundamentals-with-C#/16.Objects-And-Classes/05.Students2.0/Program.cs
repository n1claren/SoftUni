using System;
using System.Collections.Generic;

namespace _05.Students2._0
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



                if (isStudentExisting(students, name, lastName))
                {
                    Student student = GetStudent(students, name, lastName);

                    student.FirstName = name;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Town = town;
                }
                else
                {
                    Student student = new Student();

                    student.FirstName = name;
                    student.LastName = lastName;
                    student.Age = age;
                    student.Town = town;

                    students.Add(student);
                }

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

        static bool isStudentExisting(List<Student> students, string firstName, string lastName)
        {
            bool isExisting = false;
            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    isExisting = true;
                }
                else
                {
                    isExisting = false;
                }
            }

            return isExisting;
        }

        static Student GetStudent(List<Student> students, string firstName, string lastName)
        {
            Student existingStudent = null;

            foreach (Student student in students)
            {
                if (student.FirstName == firstName && student.LastName == lastName)
                {
                    existingStudent = student;
                }
            }

            return existingStudent;
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
