USE Bank
GO

CREATE TABLE NotificationEmails
(
	Id INT IDENTITY PRIMARY KEY,
	Recipient INT NOT NULL, 
	[Subject] NVARCHAR(MAX) NOT NULL, 
	Body NVARCHAR(MAX) NOT NULL
)
GO

CREATE	TRIGGER tr_OnInsertToLogsTableCreateNewEmail
ON Logs FOR INSERT
AS
	INSERT INTO NotificationEmails(Recipient, [Subject], Body)
	SELECT AccountId, 
		   CONCAT('Balance change for account: ' , CAST(AccountId AS NVARCHAR(20))),
		   CONCAT('On ', CONVERT(NVARCHAR(20), GETDATE(), 100), ' your balance was changed from ',
				  CAST(OldSum AS NVARCHAR(20)), ' to ', CAST(NewSum AS NVARCHAR(20)),'.'
				 )
		FROM Logs
GO

UPDATE Accounts
	SET Balance -= 10000
	WHERE Id BETWEEN 3 AND 6
GO

SELECT *
	FROM NotificationEmails
