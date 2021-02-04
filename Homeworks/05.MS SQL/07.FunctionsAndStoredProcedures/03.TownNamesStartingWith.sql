USE SoftUni
GO

CREATE PROCEDURE usp_GetTownsStartingWith (@Letter VARCHAR(15))
AS
BEGIN
	SELECT [Name]
	FROM Towns
	WHERE LEFT([Name], 1) = LEFT(@Letter, 1)
END
GO

EXEC usp_GetTownsStartingWith 'BABO'