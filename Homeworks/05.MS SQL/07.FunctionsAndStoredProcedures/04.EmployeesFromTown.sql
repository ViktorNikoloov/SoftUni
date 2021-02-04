USE SoftUni
GO

CREATE PROCEDURE usp_GetEmployeesFromTown (@TownName VARCHAR(15))
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees AS e
		JOIN Addresses AS a ON a.AddressID = e.AddressID
		JOIN Towns AS t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName
END
GO

EXEC usp_GetEmployeesFromTown 'Sofia'
