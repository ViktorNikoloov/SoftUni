USE TripService
GO

SELECT  t.Id, 
		CONCAT(a.FirstName, ' ', 
		IIF(a.MiddleName IS NOT NULL,a.MiddleName + ' ' , ''), a.LastName) AS [Full Name],
		ac.[Name] AS [From],
		hc.[Name] AS [To],
		CASE
			WHEN t.CancelDate IS NULL THEN CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate), ' ', 'days')
			ELSE 'Canceled'
		END	AS [Duration]
	FROM AccountsTrips AS [at]
	JOIN Accounts AS a ON [at].AccountId = a.Id
	JOIN Cities AS ac ON a.CityId = ac.Id
	JOIN Trips AS t ON at.TripId = t.Id
	JOIN Rooms AS r ON t.RoomId = r.Id
	JOIN Hotels AS h ON r.HotelId = h.Id
	JOIN Cities AS hc ON h.CityId = hc.Id
	ORDER BY [Full Name] ASC,
			 t.Id ASC