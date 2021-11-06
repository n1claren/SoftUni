using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext db = new SoftUniContext();
        }


        // 03. Employees Full Information
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employees = context.Employees.ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} {e.MiddleName} {e.JobTitle} {e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 04. Employees with Salary Over 50 000
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            Employee[] employees = context
                .Employees
                .Where(e => e.Salary > 50000)
                .OrderBy(e => e.FirstName)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 05. Employees from Research and Development
        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary 
                })
                .ToArray();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.DepartmentName} - ${e.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        // 06. Adding a New Address and Updating Employee 
        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var newAddress = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            context
                .Employees
                .FirstOrDefault(e => e.LastName == "Nakov")
                .Address = newAddress;
            
            context.SaveChanges();

            var employeeAddresses = context
                .Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => new { e.Address.AddressText })
                .ToList();

            foreach (var emp in employeeAddresses)
            {
                sb.AppendLine(emp.AddressText);
            }

            return sb.ToString().Trim();
        }

        // 07. Employees and Projects
        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.EmployeesProjects.Any(x => x.Project.StartDate.Year >= 2001 && x.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,

                    Projects = e
                    .EmployeesProjects
                    .Select(p => new
                        {
                            Name = p.Project.Name,
                            StartDate = p.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = p.Project.EndDate.HasValue ?
                            p.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture) : "not finished"
                        })
                })
                .Take(10)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - Manager: {e.ManagerFirstName} {e.ManagerLastName}");

                foreach (var p in e.Projects)
                {
                    sb.AppendLine($"--{p.Name} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().Trim();
        }

        // 08. Addresses by Town
        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var addresses = context
                .Addresses
                .Select(a => new
                    {
                        a.AddressText,
                        TownName = a.Town.Name,
                        EmployeeCount = a.Employees.Count
                    })
                    .OrderByDescending(a => a.EmployeeCount)
                    .ThenBy(a => a.TownName)
                    .ThenBy(a => a.AddressText)
                    .Take(10);

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().Trim();
        }

        // 09. Employee 147 
        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Select(e => new
                {
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .Select(x => x.Project.Name)
                        .OrderBy(p => p)
                        .ToList()
                })
                .SingleOrDefault(e => e.EmployeeId == 147);

            sb.AppendLine($"{employees.FirstName} {employees.LastName} - {employees.JobTitle}");

            foreach (var project in employees.Projects)
            {
                sb.AppendLine($"{project}");
            }

            return sb.ToString().Trim();
        }

        //  10. Departments with More Than 5 Employees 
        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context
                    .Departments
                    .Where(d => d.Employees.Count > 5)
                    .OrderBy(d => d.Employees.Count)
                    .ThenBy(d => d.Name)
                    .Select(d => new
                    {
                        DepartmentName = d.Name,
                        ManagerFirstName = d.Manager.FirstName,
                        ManagerLastName = d.Manager.LastName,
                        Employees = d.Employees
                            .Select(e => new
                            {
                                e.FirstName,
                                e.LastName,
                                e.JobTitle
                            })
                            .OrderBy(e => e.FirstName)
                            .ThenBy(e => e.LastName)
                            .ToList()
                    })
                    .ToList();

            foreach (var dept in departments)
            {
                sb.AppendLine($"{dept.DepartmentName} - {dept.ManagerFirstName} {dept.ManagerLastName}");

                foreach (var emp in dept.Employees)
                {
                    sb.AppendLine($"{emp.FirstName} {emp.LastName} - {emp.JobTitle}");
                }
            }

            return sb.ToString().Trim();
        }

        //  11. Find Latest 10 Projects 
        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var projects = context
                .Projects
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .ToList();

            foreach (var project in projects)
            {
                sb.AppendLine($"{project.Name}");
                sb.AppendLine($"{project.Description}");
                sb.AppendLine(project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
            }

            return sb.ToString().Trim();
        }

        //  12. Increase Salaries 
        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(p => p.Department.Name == "Engineering" ||
                    p.Department.Name == "Tool Design" ||
                    p.Department.Name == "Marketing" ||
                    p.Department.Name == "Information Services")
                .OrderBy(p => p.FirstName)
                .ThenBy(p => p.LastName)
                .ToList();

            foreach (var emp in employees)
            {
                emp.Salary *= 1.12M;
            }

            context.SaveChanges();

            foreach (var emp in employees)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} (${emp.Salary:F2})");
            }

            return sb.ToString().Trim();
        }

        // 13. Find Employees by First Name Starting With Sa 
        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context
                .Employees
                .Where(e => e.FirstName.StartsWith("SA") || e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().Trim();
        }

        //  14. Delete Project by Id
        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employeesProjects = context
                .EmployeesProjects
                .Where(ep => ep.ProjectId == 2)
                .ToList();

            foreach (var ep in employeesProjects)
            {
                context.EmployeesProjects.Remove(ep);
            }

            var projects = context.Projects.Find(2);
            context.Projects.Remove(projects);

            context.SaveChanges();

            var projectData = context
                .Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            foreach (var project in projectData)
            {
                sb.AppendLine(project);
            }

            return sb.ToString().Trim();
        }

        // 15. Remove Town 
        public static string RemoveTown(SoftUniContext context)
        {
            var employees = context
                .Employees
                .Where(e => e.Address.Town.Name == "Seattle");

            foreach (var employee in employees)
            {
                employee.AddressId = null;
            }

            var addresses = context.Addresses.Where(a => a.Town.Name == "Seattle");

            int count = 0;

            foreach (var address in addresses)
            {
                context.Addresses.Remove(address);
                count++;
            }

            var town = context.Towns.FirstOrDefault(t => t.Name == "Seattle");

            context.Towns.Remove(town);

            context.SaveChanges();

            return $"{count} addresses in Seattle were deleted";
        }
    }
}