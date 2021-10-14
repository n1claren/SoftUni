CREATE FUNCTION ufn_CalculateFutureValue (@sum DECIMAL(20, 4), @interest_rate FLOAT, @num_of_years INT)
	RETURNS DECIMAL(20, 4)
	AS
	BEGIN
	RETURN (@sum * (POWER((1 + @interest_rate), @num_of_years)))
	END