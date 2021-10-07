SELECT * FROM (
SELECT EmployeeID, FirstName, LastName, Salary, 
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS Ranking
	FROM Employees
		WHERE Salary BETWEEN 10000 AND 50000
) AS Result
	WHERE Ranking = 2
		ORDER BY Salary DESC