USE SoftUni
GO

SELECT COUNT
(e.Salary) AS [Count]
	FROM Employees AS e
	LEFT JOIN Employees AS m ON e.ManagerID = m.ManagerID
WHERE  m.ManagerID IS NULL