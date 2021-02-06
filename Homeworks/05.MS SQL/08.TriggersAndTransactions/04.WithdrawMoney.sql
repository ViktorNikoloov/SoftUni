USE Bank
GO

CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
	BEGIN TRANSACTION
		IF(@MoneyAmount < 0)
			BEGIN
				THROW 50005,'Amount should be positive', 1;
			END
		ELSE IF(SELECT COUNT(*)
					FROM Accounts
					WHERE Id = @AccountId
			   ) < 1
			BEGIN 
				THROW 50006,'Invalid AccountId', 1;
			END
	UPDATE Accounts
		SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
COMMIT
END
GO

EXEC usp_WithdrawMoney 123, 15
GO

EXEC usp_WithdrawMoney 1, -123
GO

EXEC usp_WithdrawMoney 1, 15
GO

SELECT * 
	FROM Logs
GO

SELECT *
	FROM NotificationEmails
GO


/*SecondSolution*/
CREATE PROCEDURE usp_WithdrawMoney(@AccountId INT, @MoneyAmount DECIMAL(18,4))
AS
BEGIN
	BEGIN TRANSACTION
		IF(@MoneyAmount > 0)
			BEGIN
				UPDATE Accounts
					SET Balance -= @MoneyAmount
					WHERE Id = @AccountId
			
				IF @@ROWCOUNT != 1
				BEGIN
					ROLLBACK
					RAISERROR('Invalid account!', 16, 1)
					RETURN
				END
			END
COMMIT
END
GO

EXEC usp_WithdrawMoney 123, 15
GO

EXEC usp_WithdrawMoney 1, -123
GO

EXEC usp_WithdrawMoney 1, 15
GO

SELECT * 
	FROM Logs
GO

SELECT *
	FROM NotificationEmails
GO
