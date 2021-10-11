SELECT mc.CountryCode, COUNT(m.MountainRange) AS MountainRanges
	FROM MountainsCountries mc
	JOIN Mountains m ON mc.MountainId = m.Id
	WHERE mc.CountryCode IN ('US', 'RU', 'BG')
	GROUP BY (mc.CountryCode)