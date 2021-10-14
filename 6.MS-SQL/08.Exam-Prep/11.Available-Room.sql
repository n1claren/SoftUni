CREATE OR ALTER FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS NVARCHAR(MAX)
BEGIN
	DECLARE @RoomInfo VARCHAR(MAX) = (SELECT TOP(1) 'Room ' + CONVERT(VARCHAR, r.Id) + ': ' + r.Type + 
	' (' + CONVERT(VARCHAR, r.Beds) + ' beds) - $' + CONVERT(VARCHAR, (BaseRate + Price) * @People)
	FROM Rooms r
	JOIN Hotels h ON r.HotelId = r.Id
	WHERE Beds >= @People AND HotelId = @HotelId AND 
		NOT EXISTS (SELECT * FROM Trips t WHERE t.RoomId = r.Id
								AND CancelDate IS NULL
								AND @Date BETWEEN ArrivalDate AND ReturnDate)
	ORDER BY (BaseRate + Price) * @People DESC);

	IF (@RoomInfo IS NULL)
		RETURN 'No rooms available';
	RETURN @RoomInfo;
END


