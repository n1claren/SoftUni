CREATE PROC usp_GetEmployeesSalaryAboveNumber @number DECIMAL(20, 2)
	AS 
	SELECT [FirstName], [LastName]
	FROM [Employees]
	WHERE [Salary] >= @number
