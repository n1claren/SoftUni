SELECT [Name],

	CASE
		WHEN [Hour] BETWEEN 0 AND 11 THEN 'Morning'
		WHEN [Hour] BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN [Hour] BETWEEN 18 AND 23 THEN 'Evening'
	END	AS [Part of the Day],

	CASE
		WHEN  [Duration] <=3 THEN 'Extra Short'
		WHEN [Duration] BETWEEN 4 AND 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END	AS [Duration]

FROM (SELECT [Name], DATEPART(HOUR, [Start]) AS [Hour], [Duration] FROM Games ) AS TMP

ORDER BY [Name], [Duration], [Part of the Day]