SELECT c.Id, c.CigarName, c.PriceForSingleCigar, t.TasteType, t.TasteStrength FROM Cigars c
	JOIN Tastes t ON c.TastId = t.Id
	WHERE t.Id IN (2, 3)
	ORDER BY PriceForSingleCigar DESC