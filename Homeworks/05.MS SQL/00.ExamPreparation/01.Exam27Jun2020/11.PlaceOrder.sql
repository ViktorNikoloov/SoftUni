USE WMS
GO

CREATE PROCEDURE usp_PlaceOrder(@JobId INT, 
								@PartSerialNumber  VARCHAR(50), 
								@Quantity INT)
AS
	BEGIN
		IF(@Quantity <= 0)
			BEGIN
				THROW 50012, 'Part quantity must be more than zero!', 1
			END
		IF((SELECT [Status] 
			FROM Jobs 
			WHERE JobId = @JobId) = 'Finished')
			BEGIN
				THROW 50011, 'This job is not active!', 1
			END
		

		DECLARE @isJobNull INT = 
			(
				SELECT JobId 
				FROM Jobs 
				WHERE JobId = @JobId
			)
		IF(@isJobNull IS NULL)
			BEGIN
				THROW 50013, 'Job not found!', 1
			END

		DECLARE @partId INT = 
			(
				SELECT PartId 
				FROM Parts 
				WHERE SerialNumber = @PartSerialNumber
			 )
		IF(@partId IS NULL)
			BEGIN
				THROW 50014, 'Part not found!', 1
			END
		IF((SELECT OrderId
				FROM Orders
				WHERE JobId = @JobId
				  AND IssueDate IS NULL) IS NULL)
			BEGIN
				INSERT INTO Orders(JobId, IssueDate, Delivered)
					VALUES(@JobId, NULL, 0)
			END

		DECLARE @orderId INT = 
			(
				SELECT OrderId
				FROM Orders
				WHERE JobId = @JobId
				  AND IssueDate IS NULL
		    )
		

		DECLARE @orderPartsQuantity INT = 
			(
				SELECT Quantity
				FROM OrderParts
				WHERE OrderId = @orderId
				  AND PartId = @partId
			)
		IF(@orderPartsQuantity IS NULL)
			BEGIN
				INSERT INTO OrderParts(OrderId, PartId, Quantity)
					 VALUES (@orderId, @partId, @Quantity)
			END
		ELSE
			BEGIN
				UPDATE OrderParts
					SET Quantity += @Quantity
					WHERE OrderId = @orderId
					AND PartId = @partId
			END

	END
GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH
GO


DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

BEGIN TRY
  EXEC usp_PlaceOrder 23213213, 'JobNotFound', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

BEGIN TRY
  EXEC usp_PlaceOrder 2, 'JobNotActive', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

BEGIN TRY
  EXEC usp_PlaceOrder 45, 'PartNotFound', 1
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH