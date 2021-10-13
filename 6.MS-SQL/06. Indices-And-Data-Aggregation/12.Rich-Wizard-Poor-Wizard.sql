SELECT SUM(Difference)
FROM
	(SELECT
		FirstName AS Host, DepositAmount AS HostDeposit,
		LEAD(FirstName) OVER (ORDER BY Id) AS Guest, 
		LEAD(DepositAmount) OVER (ORDER BY Id) AS GuestDeposit,
		(DepositAmount-LEAD(DepositAmount) OVER (ORDER BY Id)) AS Difference
		FROM WizzardDeposits) AS temp