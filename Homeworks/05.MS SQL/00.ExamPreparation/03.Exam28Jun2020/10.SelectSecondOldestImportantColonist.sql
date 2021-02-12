USE ColonialJourney
GO

SELECT JobDuringJourney,  [FullName], [JobRank]
	FROM (
			SELECT  tc.JobDuringJourney, 
			CONCAT(c.FirstName, ' ', c.LastName) AS [FullName],
			RANK()
				OVER (PARTITION BY tc.JobDuringJourney 
						ORDER BY c.BirthDate ASC) AS [JobRank]
			FROM Colonists AS c
			JOIN TravelCards AS tc ON c.Id = tc.ColonistId
			JOIN Journeys AS j ON tc.JourneyId = j.Id
		 ) AS [JobsRankQuery]
		WHERE [JobRank] = 2