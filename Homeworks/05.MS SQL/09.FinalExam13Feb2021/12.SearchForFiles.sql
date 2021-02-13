USE Bitbucket
GO

CREATE PROCEDURE usp_SearchForFiles(@fileExtension VARCHAR(20))
	AS
BEGIN
	DECLARE @WildCardExp VARCHAR(20) 
				= CONCAT('%', @fileExtension)
	SELECT  f.Id, 
			f.[Name], 
			CONCAT(f.Size, 'KB') AS [Size]
		FROM Users AS u
		JOIN Commits AS c ON u.Id = c.ContributorId
		JOIN Files AS f ON c.Id = f.CommitId
		WHERE f.[Name] LIKE @WildCardExp
END
GO

EXEC usp_SearchForFiles 'txt'
/* 
|          Output           |
|Id|   Name    |    Size    |
|28| Jason.txt | 10317.54KB |
|31| file.txt  | 5514.02KB  |
|43| init.txt  | 16089.79KB |
*/

