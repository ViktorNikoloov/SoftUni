USE WMS
GO

SELECT CONCAT(m.FirstName, ' ', m.LastName) AS [Mechanic],
	   AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
	FROM Mechanics AS m
	JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE FinishDate IS NOT NULL
GROUP BY m.MechanicId, m.FirstName, m.LastName
ORDER BY m.MechanicId ASC