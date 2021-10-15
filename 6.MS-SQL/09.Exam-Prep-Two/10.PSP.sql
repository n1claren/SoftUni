SELECT p.Name, p.Seats, ISNULL(COUNT(t.PassengerId), 0) AS PassengerCount
FROM Planes p
LEFT JOIN Flights f ON p.Id = f.PlaneId
LEFT JOIN Tickets t ON f.Id = t.FlightId
GROUP BY p.Name, p.Seats
ORDER BY PassengerCount DESC, p.Name, p.Seats