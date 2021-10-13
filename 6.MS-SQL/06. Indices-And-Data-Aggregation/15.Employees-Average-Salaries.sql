SELECT DepartmentID, Salary, ManagerID
	INTO TempTable
	FROM Employees
	WHERE SALARY > 30000

DELETE FROM TempTable
	WHERE ManagerID = 42

UPDATE TempTable
	SET SALARY += 5000
	WHERE DepartmentID = 1

SELECT DepartmentID, AVG(Salary)
	FROM TempTable
	GROUP BY DepartmentID