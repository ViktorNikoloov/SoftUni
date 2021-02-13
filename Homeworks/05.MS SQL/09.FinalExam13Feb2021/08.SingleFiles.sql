USE Bitbucket
GO

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