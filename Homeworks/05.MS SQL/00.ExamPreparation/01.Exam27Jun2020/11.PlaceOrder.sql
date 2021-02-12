USE WMS
GO

CREATE PROCEDURE usp_PlaceOrder(@JobID INT, 
								@PartSerialNum VARCHAR(50), 
								@Quantity INT)
AS
BEGIN

	DECLARE @IsJobIdIsNull INT = (
									SELECT JobId 
									FROM Jobs 
									WHERE JobId = @JobID
								 )

	DECLARE @PartID INT = (
							SELECT PartId 
							FROM Parts 
							WHERE SerialNumber = @PartSerialNum
						  )

	DECLARE @OrderID INT = (
							SELECT OrderID
							FROM Orders
							WHERE JobId = @JobID
							  AND IssueDate IS NULL
						   )

	DECLARE @OrderPartsQuantity INT = (
										SELECT Quantity
										FROM OrderParts
										WHERE OrderId = @OrderID
										  AND PartId = @PartID
									  )

	IF((SELECT [Status] 
		FROM Jobs 
		WHERE JobId = @JobID) = 'Finished')
		BEGIN
			THROW 5011, 'This job is not active!', 1
		END
	IF(@Quantity <= 0)
		BEGIN
			THROW 5012, 'Part quantity must be more than zero!', 1
		END
	IF(@IsJobIdIsNull IS NULL)
		BEGIN
			THROW 5013, 'Job not found!', 1
		END
	IF(@PartID IS NULL)
		BEGIN
			THROW 5014, 'Part not found!', 1
		END
	
	IF (@OrderID IS NULL)
		BEGIN
			INSERT INTO Orders(JobId, IssueDate, Delivered)
				VALUES(@JobID, NULL, 0)
		END

	IF(@OrderPartsQuantity IS NULL)
		BEGIN
			INSERT INTO OrderParts(OrderId, PartId, Quantity)
				 VALUES (@OrderID, @PartID, @Quantity)
		END
	ELSE
		BEGIN
			UPDATE OrderParts
				SET Quantity += @Quantity
				WHERE OrderId = @OrderID
				AND PartId = @PartID
		END

END
GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg AS [Response]
END CATCH
GO
