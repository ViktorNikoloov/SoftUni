USE Gringotts
GO

SELECT [FirstName's first letter]
	FROM (
			SELECT SUBSTRING(FirstName, 1, 1) AS [FirstName's first letter]
				FROM WizzardDeposits
				WHERE DepositGroup LIKE 'Troll Chest'
	     ) AS [FirstCharQuery]
GROUP BY [FirstName's first letter]
ORDER BY [FirstName's first letter]