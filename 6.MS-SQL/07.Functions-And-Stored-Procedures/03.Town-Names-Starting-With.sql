CREATE PROC usp_GetTownsStartingWith @string NVARCHAR(MAX)
	AS
		SELECT [Name] AS [Town]
		FROM [Towns]
		WHERE [Name] LIKE @string + '%'