USE SoftUni
GO

SELECT Name
	FROM Towns
	WHERE LEN([Name]) BETWEEN 5 AND 6
	--WHERE LEN([Name]) IN (5, 6)
	ORDER BY [Name] ASC