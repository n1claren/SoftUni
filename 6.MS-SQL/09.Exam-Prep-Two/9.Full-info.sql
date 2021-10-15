SELECT  CONCAT(ps.FirstName, ' ', ps.LastName) AS [Full Name],
		p.Name AS [Plane Name],
		CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
		lt.Type AS [Luggage Type]
FROM Passengers ps 
JOIN Tickets t ON ps.Id = t.PassengerId
JOIN Flights f ON t.FlightId = f.Id
JOIN Planes p ON f.PlaneId = p.Id
JOIN Luggages l ON t.LuggageId = l.Id
JOIN LuggageTypes lt ON l.LuggageTypeId = lt.Id
ORDER BY [Full Name], [Plane Name], f.Origin, f.Destination, [Luggage Type]