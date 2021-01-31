USE Gringotts
GO

SELECT DepositGroup, SUM(DepositAmount) AS [Group's total deposit sum by Olivivander family's cafted wands]
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup
	HAVING SUM(DepositAmount) < 150000
	ORDER BY [Group's total deposit sum by Olivivander family's cafted wands] DESC