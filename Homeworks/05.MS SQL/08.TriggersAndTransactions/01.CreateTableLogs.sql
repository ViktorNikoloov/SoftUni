USE Bank
GO

CREATE TABLE Logs
(
	LogId INT IDENTITY PRIMARY KEY,
	AccountId INT NOT NULL,
	OldSum DECIMAL(18,4) NOT NULL,
	NewSum DECIMAL(18,4) NOT NULL
)
GO

CREATE TRIGGER tr_OnAccoutChangesAddLogRecord
ON Accounts FOR UPDATE
AS
	INSERT INTO Logs(AccountId, OldSum, NewSum)
		SELECT i.Id, d.Balance, i.Balance
			FROM inserted AS i
			JOIN deleted AS d ON i.Id = d.Id
GO