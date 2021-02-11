USE TripService
GO

SELECT TOP(10) c.Id, [Name], CountryCode, COUNT(*) AS [Accounts]
	FROM Cities AS c
	JOIN Accounts AS a ON c.Id = a.CityId
	GROUP BY c.Id, [Name], CountryCode
	ORDER BY [Accounts] DESC