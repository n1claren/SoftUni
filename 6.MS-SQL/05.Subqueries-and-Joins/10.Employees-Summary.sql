SELECT TOP(50) e.EmployeeID,
			CONCAT(e.FirstName, ' ', e.LastName) AS EmployeeName,
			CONCAT(m.FirstName, ' ', m.LastName) AS ManagerName,
			-- CONCAT_WS is not supported by the SoftUni judge system -_-
			d.Name
	FROM Employees e
	JOIN Employees m ON e.ManagerID = m.EmployeeID
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	ORDER BY e.EmployeeID