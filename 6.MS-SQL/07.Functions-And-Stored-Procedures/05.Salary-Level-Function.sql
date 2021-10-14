CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(20, 2))
	RETURNS NVARCHAR(7)
	AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(7)

	SET @SalaryLevel =
		CASE
		WHEN @salary < 30000 THEN 'Low'
		WHEN @salary BETWEEN 30000 AND 50000 THEN 'Average'
		ELSE 'High'
		END

	RETURN @SalaryLevel
END