SELECT MountainRange, PeakName, Elevation 
	FROM Mountains
	JOIN Peaks ON MountainId = Mountains.Id
	WHERE Mountains.MountainRange = 'Rila'
	ORDER BY Peaks.Elevation DESC