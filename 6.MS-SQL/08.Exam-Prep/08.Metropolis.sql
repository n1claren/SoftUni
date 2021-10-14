SELECT TOP(10) c.Id, c.Name AS City, c.CountryCode AS Country, COUNT(*) AS Accounts
FROM Accounts a
JOIN Cities c ON a.CityId = c.Id
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC