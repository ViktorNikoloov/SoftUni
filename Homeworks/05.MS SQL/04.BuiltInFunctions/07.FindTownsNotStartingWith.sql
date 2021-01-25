USE SoftUni
GO

SELECT TownID, [Name]
	FROM Towns
	WHERE [Name] NOT LIKE '[R, B, D]%'
	ORDER BY [Name] ASC