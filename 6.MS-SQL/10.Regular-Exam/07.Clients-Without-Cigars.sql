SELECT c.Id, CONCAT(c.FirstName, ' ', c.LastName) AS ClientName, c.Email 
	FROM Clients c
	LEFT JOIN ClientsCigars cc ON cc.ClientId = c.Id
	LEFT JOIN Cigars cig ON cc.CigarId = cig.Id
	WHERE cig.Id IS NULL
	ORDER BY FirstName