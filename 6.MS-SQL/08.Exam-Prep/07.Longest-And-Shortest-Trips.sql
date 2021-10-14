SELECT at.AccountId,
	FirstName + ' ' + LastName AS FullName,
	MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
	MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
FROM AccountsTrips at
JOIN Accounts a ON at.AccountId = a.Id
JOIN Trips t ON at.TripId = t.Id
WHERE MiddleName IS NULL AND CancelDate IS NULL
GROUP BY at.AccountId, FirstName, LastName
ORDER BY LongestTrip DESC, ShortestTrip