using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public int Capacity { get; set; }

        public int Count { get { return students.Count; } }

        public Classroom(int capacity)
        {
            this.Capacity = capacity;

            this.students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (this.Count < this.Capacity)
            {
                students.Add(student);

                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(student => student.FirstName == firstName && student.LastName == lastName))
            {
                for (int i = 0; i < students.Count; i++)
                {
                    if (students[i].FirstName == firstName && students[i].LastName == lastName)
                    {
                        students.Remove(students[i]);
                        return $"Dismissed student {firstName} {lastName}";
                    }
                }
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            var result = new StringBuilder();

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Subject == subject)
                {
                    result.AppendLine($"{students[i].FirstName} {students[i].LastName}");
                }
            }

            if (result.Length > 0)
            {
                var finalResult = new StringBuilder();

                finalResult.AppendLine($"Subject: {subject}");
                finalResult.AppendLine($"Students:");
                finalResult.AppendLine(result.ToString());

                return finalResult.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount()
        {
            return this.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            Student student = null;

            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].FirstName == firstName &&
                    students[i].LastName == lastName)
                {
                    student = students[i];
                }
            }

            return student;
        }
    }
}
