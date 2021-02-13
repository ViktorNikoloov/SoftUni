USE Bitbucket
GO

CREATE FUNCTION udf_AllUserCommits(@username VARCHAR(30))
RETURNS INT
	AS
BEGIN
	DECLARE @result INT =
		(
		  SELECT COUNT(c.Id) AS [Commits Count]
			FROM Users AS u
			JOIN Commits AS c ON u.Id = c.ContributorId
			WHERE u.Username = @username
		)
	RETURN @result
END
GO

SELECT dbo.udf_AllUserCommits('UnderSinduxrein') --Output - 6
