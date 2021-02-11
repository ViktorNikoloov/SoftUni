USE TripService
GO

SELECT a.ID, a.Email, c.[Name], COUNT(*) AS [Trips]
	FROM AccountsTrips AS [at]
	JOIN Accounts AS a ON [at].AccountId = a.Id
	JOIN Cities AS c ON a.CityId = c.Id
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	WHERE a.CityId = h.CityId
	GROUP BY a.ID, a.Email, c.[Name]
	ORDER BY [Trips] DESC,
			 a.Id

