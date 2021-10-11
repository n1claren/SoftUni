SELECT TOP(5) CountryName, Elevation AS HighestPeakElevation, Length AS LongestRiverLength
	FROM
		(SELECT CountryName,
			DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Elevation DESC) AS [Peak Rank],
			Elevation, PeakName,
			DENSE_RANK() OVER (PARTITION BY CountryName ORDER BY Length DESC) AS [River Rank],
			RiverName,
			Length
		FROM
			(SELECT c.CountryName, p.PeakName, p.Elevation, r.RiverName, r.Length
				FROM Countries c
			LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
			LEFT JOIN Mountains m ON mc.MountainId = m.Id
			LEFT JOIN Peaks p ON mc.MountainId = p.MountainId
			LEFT JOIN CountriesRivers cr ON c.CountryCode =  cr.CountryCode	
			LEFT JOIN Rivers r ON cr.RiverId = r.Id) 
			AS BasicQuery) 
			AS RankQuery

WHERE [Peak Rank] = 1 AND [River Rank] = 1

ORDER BY HighestPeakElevation DESC, LongestRiverLength DESC, CountryName