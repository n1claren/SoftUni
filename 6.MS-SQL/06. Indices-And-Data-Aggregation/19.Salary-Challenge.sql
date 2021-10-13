SELECT TOP(10) e.FirstName, e.LastName, e.DepartmentID
	FROM Employees e
	JOIN 
	(SELECT DepartmentID, AVG(Salary) AS AvgSalary
		FROM Employees
		GROUP BY DepartmentID) AS t ON e.DepartmentID = t.DepartmentID
	WHERE Salary > AvgSalary
	ORDER BY e.DepartmentID