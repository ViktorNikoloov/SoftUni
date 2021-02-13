USE Bitbucket
GO

DECLARE @deletedId INT = 
	(
		SELECT  Id
		FROM Repositories
		WHERE Name = 'Softuni-Teamwork'
	)

DELETE FROM Issues
	WHERE RepositoryId = @deletedId

DELETE FROM RepositoriesContributors
	WHERE RepositoryId = @deletedId