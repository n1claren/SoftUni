CREATE PROC usp_SearchByTaste @taste NVARCHAR(20)
	AS
		SELECT c.CigarName, CONCAT('$',c.PriceForSingleCigar) AS Price, t.TasteType, b.BrandName,
			CONCAT(s.Length, ' cm') AS CigarLength,
			CONCAT(s.RingRange, ' cm') AS CigarRingRange
		FROM Tastes t 
		JOIN Cigars c ON t.Id = c.TastId
		JOIN Brands b ON c.BrandId = b.Id
		JOIN Sizes s ON c.SizeId = s.Id
		WHERE t.TasteType = @taste
		ORDER BY CigarLength, CigarRingRange DESC