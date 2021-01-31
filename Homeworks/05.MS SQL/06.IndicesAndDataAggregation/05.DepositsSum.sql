USE Gringotts
GO

SELECT DepositGroup, SUM(DepositAmount) AS [Group's deposit amount]
	FROM WizzardDeposits
	GROUP BY DepositGroup