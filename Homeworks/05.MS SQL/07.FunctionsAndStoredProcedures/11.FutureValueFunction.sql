USE Bank
GO

ALTER FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18,4), @Rate FLOAT, @Year INT)
RETURNS DECIMAL(18,4)
AS
BEGIN
	--Formula FV=I×(〖(1+R)〗^T) => @Sum*(POWER((1+@Rate), @Year))
	DECLARE @FutureValue DECIMAL(18,4);

	SET @FutureValue = @Sum*(POWER(1+@Rate, @Year));
	RETURN @FutureValue;
END
GO

SELECT dbo.ufn_CalculateFutureValue(123.12, 0.1, 5)