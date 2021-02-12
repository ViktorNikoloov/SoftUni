USE ColonialJourney
GO

CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11) )
AS
	BEGIN
		IF(SELECT Id FROM Journeys WHERE Id = @JourneyId) IS NULL
			BEGIN
				THROW 50001, 'The journey does not exist!', 1;
			END
		IF(SELECT Purpose FROM Journeys WHERE Id = @JourneyId) = @NewPurpose
			BEGIN
				THROW 50002, 'You cannot change the purpose!', 1;
			END
		UPDATE Journeys
			SET Purpose = @NewPurpose
	END
GO


--|                   Query			                 |             Output              |
	EXEC usp_ChangeJourneyPurpose 4, 'Technical'   --|                                 |
	EXEC usp_ChangeJourneyPurpose 2, 'Educational' --|  You cannot change the purpose! |
	EXEC usp_ChangeJourneyPurpose 196, 'Technical' --|  The journey does not exist!    |
