CREATE FUNCTION udf_CalculateTickets(@origin NVARCHAR(50), @destination NVARCHAR(50), @peopleCount INT)
RETURNS NVARCHAR(MAX)
AS
BEGIN
		IF (@peopleCount <= 0)
			RETURN 'Invalid people count!';
		
		DECLARE @FLIGHTID INT = (SELECT ID FROM Flights
								WHERE ORIGIN = @ORIGIN
								AND Destination = @DESTINATION);

		IF (@FLIGHTID IS NULL)
		 	RETURN 'Invalid flight!';
			
		DECLARE @TICKETPRICE DECIMAL(20, 2) = (SELECT PRICE FROM Tickets WHERE FLIGHTID = @FLIGHTID);

		DECLARE @TOTALPRICE DECIMAL(20, 2) = @TICKETPRICE * @PEOPLECOUNT;

		RETURN 'Total price ' + CAST(@TOTALPRICE AS nvarchar(20));	
END