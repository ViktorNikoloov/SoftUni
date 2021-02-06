USE Bank
GO

CREATE PROCEDURE usp_DepositMoney(@AccountId INT, @Amount DECIMAL(18,4))
AS
BEGIN TRANSACTION
	IF(@Amount < 0)
		BEGIN
            THROW 50005,'Amount should be positive', 1;
        END
	ELSE IF(SELECT COUNT(*) 
				FROM Accounts
				WHERE Id = @AccountId) < 1
		BEGIN
			THROW 50006,'Invalid AccountId', 1;
		END	
	UPDATE Accounts			
	SET Balance += @Amount
	WHERE Id = @AccountId
COMMIT
GO

EXEC usp_DepositMoney 1, -123
GO

EXEC usp_DepositMoney 213, 10
GO

EXEC usp_DepositMoney 1, 10
GO

SELECT *
	FROM Logs
GO

SELECT *
	FROM NotificationEmails
GO