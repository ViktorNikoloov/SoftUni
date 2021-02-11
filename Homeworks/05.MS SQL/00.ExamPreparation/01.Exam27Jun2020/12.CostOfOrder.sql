USE WMS
GO

CREATE FUNCTION udf_GetCost(@JobId INT)
RETURNS DECIMAL(18,2)
AS
	BEGIN
		DECLARE @Result DECIMAL(18,2) = 
			(
				SELECT SUM(p.Price) AS [Result]
				FROM Jobs AS j
				JOIN Orders AS o ON j.JobId = o.JobId
				JOIN OrderParts AS op ON o.OrderId = op.OrderId
				JOIN Parts AS p ON op.PartId = p.PartId
				WHERE j.JobId = @JobId
				GROUP BY  o.JobId
			)
		IF(@Result IS NULL)
			BEGIN
				RETURN 0
			END
		RETURN @Result
	END
GO

SELECT dbo.udf_GetCost(1)
GO