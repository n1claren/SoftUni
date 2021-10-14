CREATE PROC usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
	DECLARE @TripHotelId INT = (SELECT r.HotelId FROM 
								Trips t 
								JOIN Rooms r ON t.RoomId = r.Id 
								WHERE t.Id = @TripId);

	DECLARE @TargetRoomHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId);

	IF (@TripHotelId != @TargetRoomHotelId)
		THROW 50001, 'Target room is in another hotel!', 1;

	DECLARE @TripAccounts INT = (SELECT COUNT(*) FROM AccountsTrips WHERE TripId = @TripId);

	DECLARE @TargetRoomBeds INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId);

	IF (@TripAccounts > @TargetRoomBeds)
		THROW 50002, 'Not enough beds in target room!', 2;

	UPDATE Trips SET RoomId = @TargetRoomId WHERE Id = @TripId;