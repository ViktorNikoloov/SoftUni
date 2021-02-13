USE Bitbucket
GO


SELECT  f.Id, 
		f.[Name], 
		CONCAT(f.Size, 'KB') AS [Size]
	FROM Files f
	FULL JOIN Files p ON p.ParentId = f.Id
	WHERE p.Id IS NULL
	ORDER BY Id, 
			 [Name], 
			 Size DESC

/*SecondSolution*/
SELECT  Id, 
		[Name], 
		CONCAT(Size, 'KB') AS [Size]
	FROM (
			SELECT Id, [Name], ParentId, Size
			FROM Files
		 ) [InfoQuery]
	WHERE NOT EXISTS(
						SELECT ParentId 
						FROM Files 
						WHERE [InfoQuery].Id = ParentId
					)
	ORDER BY Id ASC,
			 [Name] ASC,
			 Size DESC