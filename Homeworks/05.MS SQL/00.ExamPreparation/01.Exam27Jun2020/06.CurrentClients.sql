USE WMS
GO

SELECT CONCAT(c.FirstName, ' ', c.LastName) AS [Client], 
	   DATEDIFF(DAY, j.IssueDate, '2017/04/24') AS [Days going], 
	   j.[Status]
	FROM Clients AS c
	JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.[Status] NOT LIKE  'Finished'
ORDER BY [Days going] DESC,
		 c.ClientId ASC