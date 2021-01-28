USE SoftUni
GO

SELECT TOP(50) FirstName, LastName, t.[Name] AS Town, a.AddressText
	FROM Employees AS e
	JOIN Addresses AS a ON e.AddressID = a.AddressID
	JOIN Towns AS t ON a.TownID = t.TownID
	ORDER BY e.FirstName ASC,
			 e.LastName ASC