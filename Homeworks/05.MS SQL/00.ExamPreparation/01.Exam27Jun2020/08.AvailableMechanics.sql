USE WMS
GO

SELECT CONCAT(FirstName, ' ',LastName) AS Available
	FROM (
			SELECT FirstName, LastName, m.MechanicId
			FROM Mechanics AS m
			LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
			WHERE j.[Status] NOT LIKE 'In Progress'   
			GROUP BY m.FirstName, m.LastName, m.MechanicId
		 ) AS [InfoQuery]
	ORDER BY [InfoQuery].MechanicId