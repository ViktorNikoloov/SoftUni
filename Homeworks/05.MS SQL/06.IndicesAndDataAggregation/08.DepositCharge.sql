USE Gringotts
GO

SELECT DepositGroup, MagicWandCreator, MIN(DepositCharge) AS [Group's minimum deposit charge]
	FROM WizzardDeposits
	GROUP BY DepositGroup, MagicWandCreator
	ORDER BY MagicWandCreator,
			 DepositGroup