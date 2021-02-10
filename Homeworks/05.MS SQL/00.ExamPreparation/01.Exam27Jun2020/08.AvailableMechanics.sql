USE WMS
GO

SELECT CONCAT(FirstName, ' ',LastName) AS Available
	FROM Mechanics AS m
	LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE j.[Status] = 'Finished' OR j.JobId IS NULL
ORDER BY m.MechanicId