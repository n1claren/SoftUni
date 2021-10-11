SELECT MIN(Salary) AS MinAverageSalary
	FROM (SELECT AVG(e.Salary) AS Salary, d.Name AS DeptName
		FROM Employees e
		JOIN Departments d ON e.DepartmentID = d.DepartmentID
		GROUP BY d.Name) AS TMP