CREATE PROC usp_CalculateFutureValueForAccount @accountID INT, @interest_rate FLOAT
AS
	SELECT  ah.[Id] AS [Account Id], 
		ah.[FirstName] AS [First Name],
		ah.[LastName] AS [Last Name],
		acc.[Balance] AS [Current Balance],
		(SELECT [dbo].[ufn_CalculateFutureValue](acc.[Balance], @interest_rate, 5))	AS [Balance in % years]
	FROM AccountHolders ah
	JOIN Accounts acc ON ah.Id = acc.AccountHolderId
	WHERE acc.Id = @accountID