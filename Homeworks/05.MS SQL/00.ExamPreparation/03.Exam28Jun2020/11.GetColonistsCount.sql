USE ColonialJourney
GO

CREATE FUNCTION dbo.udf_GetColonistsCount(@PlanetName VARCHAR (30))
RETURNS INT
AS
	BEGIN
		DECLARE @Result INT = 
		(
			SELECT COUNT(c.Id) AS [Count]
				FROM Colonists AS c
				JOIN TravelCards AS tc ON c.Id = tc.ColonistId
				JOIN Journeys AS j ON tc.JourneyId = j.Id
				JOIN Spaceports AS s ON j.DestinationSpaceportId = s.Id
				JOIN Planets AS p ON s.PlanetId = p.Id
				WHERE p.[Name] LIKE @PlanetName
		)								
		RETURN @Result
	END
GO

