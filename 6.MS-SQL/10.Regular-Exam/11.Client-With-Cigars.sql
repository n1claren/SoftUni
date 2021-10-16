CREATE FUNCTION  udf_ClientWithCigars(@name NVARCHAR(30))
	RETURNS INT
	AS
	BEGIN	
	DECLARE @Count INT = (SELECT COUNT(cig.Id) FROM Clients c
					  JOIN ClientsCigars cc ON c.Id = cc.ClientId
					  JOIN Cigars cig ON cc.CigarId = cig.Id
					  WHERE FirstName = @name);

	RETURN @Count;
	END
					  
					  