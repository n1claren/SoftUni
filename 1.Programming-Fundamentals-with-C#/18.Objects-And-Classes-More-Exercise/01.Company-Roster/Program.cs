using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Company_Roster
{
    class Program
    {
        static void Main(string[] args)
        {
            int employeesCount = int.Parse(Console.ReadLine());

            List<Employee> employees = new List<Employee>();
            List<Department> departments = new List<Department>();

            for (int i = 0; i < employeesCount; i++)
            {
                var employeeData = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                Employee tempEmployee = new Employee();

                string name = employeeData[0];
                string department = employeeData[2];
                double salary = double.Parse(employeeData[1]);

                tempEmployee.Name = name;
                tempEmployee.Salary = salary;
                tempEmployee.Department = department;

                employees.Add(tempEmployee);

                if (departments.Any(x => x.DepartmentName == department))
                {
                    int index = departments.FindIndex(x => x.DepartmentName == department);

                    departments[index].EmployeeList.Add(name);
                    departments[index].TotalSalaries += salary;
                }
                else
                {
                    Department tempDepartment = new Department();

                    tempDepartment.DepartmentName = department;
                    tempDepartment.TotalSalaries += salary;
                    tempDepartment.EmployeeList.Add(name);

                    departments.Add(tempDepartment);
                }
            }

            Department bestDepartment = departments
                .OrderByDescending(x => x.TotalSalaries / x.EmployeeList.Count())
                .First();

            List<Employee> bestDepartmentEmployees = employees
                .Where(x => x.Department == bestDepartment.DepartmentName)
                .OrderByDescending(s => s.Salary)
                .ToList();

            Console.WriteLine($"Highest Average Salary: {bestDepartment.DepartmentName}");

            foreach (var employee in bestDepartmentEmployees)
            {
                Console.WriteLine($"{employee.Name} {employee.Salary:f2}");
            }

            

        }
    }

    class Employee
    {
        public string Name { get; set; }
        public double Salary { get; set; }
        public string Department { get; set; }
    }

    class Department
    {
        public string DepartmentName { get; set; }
        public List<string> EmployeeList { get; set; } = new List<string>();

        public double TotalSalaries { get; set; }
    }
}
