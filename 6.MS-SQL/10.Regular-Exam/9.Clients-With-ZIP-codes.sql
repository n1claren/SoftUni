SELECT CONCAT(c.FirstName, ' ', c.LastName) AS FullName, a.Country, a.ZIP,
	   CONCAT('$', MAX(cig.PriceForSingleCigar)) AS CigarPrice
	FROM Clients c
	JOIN Addresses a ON c.AddressId = a.Id
	JOIN ClientsCigars cc ON c.Id = cc.ClientId 
	JOIN Cigars cig ON cc.CigarId = cig.Id
	WHERE ISNUMERIC(ZIP) = 1
	GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
	ORDER BY FullName 