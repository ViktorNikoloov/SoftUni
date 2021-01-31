USE Gringotts
GO

SELECT DepositGroup, SUM(DepositAmount) AS [Group total deposit sum by Olivivander family's cafted wands]
	FROM WizzardDeposits
	WHERE MagicWandCreator = 'Ollivander family'
	GROUP BY DepositGroup