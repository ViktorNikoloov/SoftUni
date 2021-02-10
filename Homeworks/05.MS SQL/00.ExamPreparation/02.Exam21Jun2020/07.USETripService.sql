USE TripService
GO

SELECT  a.Id AS [AccountId], 
		CONCAT(FirstName, ' ', LastName) AS [FullName],
		MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS [LongestTrip], 
		MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS [ShortestTrip]
	FROM Trips AS t
	JOIN AccountsTrips AS [at] ON t.Id = [at].TripId
	JOIN Accounts AS a ON [at].AccountId = a.Id
WHERE a.MiddleName IS NULL
  AND t.CancelDate IS NULL
GROUP BY a.Id, FirstName, LastName
ORDER BY [LongestTrip] DESC,
		 [ShortestTrip] ASC
