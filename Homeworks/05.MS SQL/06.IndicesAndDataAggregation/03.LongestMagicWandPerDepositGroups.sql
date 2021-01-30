USE Gringotts
GO

SELECT DepositGroup, MAX(MagicWandSize) AS [Group's lognest magic land]
	FROM WizzardDeposits
	GROUP BY DepositGroup
