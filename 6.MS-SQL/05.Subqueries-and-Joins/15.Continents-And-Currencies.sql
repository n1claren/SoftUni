SELECT ContinentCode, CurrencyCode, CurrencyCount AS CurrencyUsage
	FROM
		(SELECT ContinentCode, CurrencyCode, CurrencyCount,
			DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC)  AS CurrencyRank
		FROM
			(SELECT ContinentCode, CurrencyCode, COUNT(CurrencyCode) AS CurrencyCount
				FROM Countries 
			GROUP BY ContinentCode, CurrencyCode) AS CountQuery
		WHERE CurrencyCount > 1) AS RankQuery
WHERE CurrencyRank = 1
ORDER BY ContinentCode
