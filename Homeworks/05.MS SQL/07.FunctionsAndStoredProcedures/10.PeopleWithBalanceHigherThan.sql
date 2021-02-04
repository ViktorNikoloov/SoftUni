USE Bank
GO

CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Money DECIMAL(18,3))
AS
BEGIN
	SELECT FirstName, 
		   LastName
		FROM(
			 SELECT ah.FirstName, ah.LastName, SUM(a.Balance) AS [TotalBalance]
			 FROM AccountHolders AS ah
			 JOIN Accounts AS a ON a.AccountHolderId = ah.Id
			 GROUP BY a.AccountHolderId, ah.FirstName, ah.LastName
			) AS [TotalBalanceQuery]
	WHERE [TotalBalance] > @Money
	ORDER BY FirstName ASC,
			 LastName ASC

END
GO

EXEC usp_GetHoldersWithBalanceHigherThan 5000000