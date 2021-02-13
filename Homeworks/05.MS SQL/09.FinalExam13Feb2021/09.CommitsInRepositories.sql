USE Bitbucket
GO


SELECT TOP(5) r.Id , 
			  r.[Name], 
			  COUNT(c.Id) AS [Commits]
	FROM RepositoriesContributors AS rc
	JOIN Repositories AS r ON rc.RepositoryId = r.Id
	JOIN Commits AS c ON r.Id = c.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY [Commits] DESC,
		 Id ASC,
		 [Name] ASC