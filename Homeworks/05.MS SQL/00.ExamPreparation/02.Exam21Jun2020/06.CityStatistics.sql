USE TripService
GO

SELECT c.[Name], COUNT(h.Id) AS [Hotels]
	FROM Cities AS c
	JOIN Hotels AS h ON c.Id = h.CityId
	GROUP BY c.[Name]
	ORDER BY [Hotels] DESC,
			 C.[Name] ASC
