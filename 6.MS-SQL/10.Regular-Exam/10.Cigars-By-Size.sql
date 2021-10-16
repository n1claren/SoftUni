SELECT c.LastName, AVG(s.Length) AS CiagrLength, CEILING(AVG(s.RingRange)) AS CiagrRingRange
	FROM Clients c
	JOIN ClientsCigars cc ON c.Id = cc.ClientId
	JOIN Cigars cig ON cc.CigarId = cig.Id
	JOIN Sizes s ON cig.SizeId = s.Id
	GROUP BY c.LastName
	ORDER BY CiagrLength DESC