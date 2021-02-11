USE TripService
GO

CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
	DECLARE @TripRoomId INT = (SELECT RoomId
									FROM Trips
									WHERE Id = @TripId
							  );
	DECLARE @TripHotelId INT = (SELECT HotelId
									FROM Rooms
									WHERE Id = @TripRoomId
							   );

	DECLARE @TargetRoomHotelId INT = (SELECT HotelId
										FROM Rooms
										WHERE Id = @TargetRoomId
									 );
	DECLARE @TargetRoomBeds INT = (SELECT Beds
									FROM Rooms
									WHERE Id = @TargetRoomId
								  );
	DECLARE @TripNeededBeds INT = (SELECT COUNT(ac.AccountId) AS [All Trip's Accounts]
									FROM Trips AS t
									JOIN AccountsTrips AS ac ON t.Id = ac.AccountId
									GROUP BY ac.TripId
									HAVING ac.TripId = @TripId
								  );

	IF(@TripHotelId != @TargetRoomHotelId)
		BEGIN
			THROW 51000, 'Target room is in another hotel!', 1;
		END
	IF(@TargetRoomBeds < @TripNeededBeds)
			BEGIN
				THROW 51001, 'Not enough beds in target room!', 1;
			END

	UPDATE Trips
		SET RoomId = @TargetRoomId
		WHERE Id = @TripId
END
GO

EXEC usp_SwitchRoom 10, 11
GO

SELECT RoomId FROM Trips WHERE Id = 10
GO