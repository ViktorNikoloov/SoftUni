USE SoftUni
GO

CREATE PROCEDURE usp_GetTownsStartingWith (@StartingString NVARCHAR(MAX))
AS
BEGIN
	SELECT [Name] AS [Town]
	FROM Towns
	WHERE LEFT([Name], LEN(@StartingString)) = @StartingString
END
GO

EXEC usp_GetTownsStartingWith 'BABO'
GO

/*SecondSolution*/
CREATE PROCEDURE usp_GetTownsStartingWith (@StartingString NVARCHAR(MAX))
AS
BEGIN
	SELECT [Name] AS [Town]
	FROM Towns
	WHERE [Name] LIKE(@StartingString + '%')
END
GO

EXEC usp_GetTownsStartingWith 'BABO'