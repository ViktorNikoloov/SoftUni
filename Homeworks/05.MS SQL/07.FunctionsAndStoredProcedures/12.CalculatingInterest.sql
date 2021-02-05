USE Bank
GO

CREATE OR ALTER PROCEDURE usp_CalculateFutureValueForAccount(@AccountID INT, @Rate FLOAT)
AS
BEGIN
	DECLARE @Years INT = 5;

	SELECT a.Id AS [Account Id], 
		   ah.FirstName AS [First Name], 
		   ah.LastName AS [LastName], 
		   a.Balance AS [Current Balance], 
		   dbo.ufn_CalculateFutureValue(a.Balance, @Rate, @Years) AS [Balance in 5 years]
		FROM AccountHolders AS ah
		JOIN Accounts AS a ON a.Id = ah.Id
		WHERE a.Id = @AccountID
END
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1