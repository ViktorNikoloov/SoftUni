USE Bitbucket
GO

SELECT Username, AVG(f.Size) AS [Size]
	FROM Commits AS c
	JOIN Users AS u ON c.ContributorId = u.Id
	JOIN Files as f on c.Id = f.CommitId
GROUP BY Username
ORDER BY [Size] DESC,
		 Username ASC