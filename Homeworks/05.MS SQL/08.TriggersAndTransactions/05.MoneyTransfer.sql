USE Bank
GO

CREATE PROCEDURE usp_TransferMoney(@SenderId INT , @ReceiverId INT, @Amount DECIMAL(18,4))
AS
BEGIN
	BEGIN TRANSACTION
		IF(SELECT COUNT(*)
			FROM Accounts
			WHERE Id = @SenderId) < 1
				BEGIN
					THROW 50005,'Invalid SenderId!', 1;
				END
		IF(SELECT COUNT(*)
			FROM Accounts
			WHERE Id = @ReceiverId) < 1
				BEGIN
					THROW 50005,'Invalid ReceiverId!', 1;
				END
		IF(@Amount < 0)
				BEGIN
					THROW 50005,'Amount should be positive!', 1;
				END
		IF(SELECT Balance
			FROM Accounts
			WHERE Id = @SenderId) < @Amount
				BEGIN
					THROW 50005,'Balance is not enough!', 1;
				END
		--UPDATE Accounts
		--	SET Balance -= @Amount
		--	WHERE Id = @SenderId
		--UPDATE Accounts
		--	SET Balance += @Amount
		--	WHERE Id = @ReceiverId
		EXEC usp_WithdrawMoney @SenderId, @Amount
		EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT
END
GO

EXEC usp_TransferMoney 123, 4, 10000
GO

EXEC usp_TransferMoney 1, 123, 10000
GO

EXEC usp_TransferMoney 1, 4, -123
GO

EXEC usp_TransferMoney 1, 4, 1000000
GO

EXEC usp_TransferMoney 1, 4, 10
GO

SELECT *
	FROM Logs
GO

SELECT *
	FROM NotificationEmails