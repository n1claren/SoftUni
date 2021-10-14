CREATE PROC usp_GetHoldersWithBalanceHigherThan (@amount DECIMAL(20, 2))
	AS
		SELECT [FirstName], [LastName]
		FROM
			(SELECT ah.[FIRSTNAME], ah.[LASTNAME], SUM(acc.BALANCE) AS [TOTAL SUM]
			FROM AccountHolders ah
			JOIN Accounts acc ON ah.Id = acc.AccountHolderId
			GROUP BY ah.Id, ah.FirstName, ah.LastName) AS temp
			WHERE [TOTAL SUM] > @amount
			ORDER BY [FirstName], [LastName]