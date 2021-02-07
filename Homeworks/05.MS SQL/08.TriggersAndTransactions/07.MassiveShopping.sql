USE Diablo
GO

DECLARE @userName VARCHAR(6) = 'Stamat'
DECLARE @gameName VARCHAR(9) = 'Safflower'

DECLARE @userID INT = (SELECT Id
						FROM Users
						WHERE Username = @userName
					  )

DECLARE @gameID INT = (SELECT Id
						FROM Games
						WHERE [Name] = @gameName
					  )

DECLARE @userGameID INT = (SELECT Id
							FROM UsersGames
							WHERE GameId = @gameID 
							  AND UserId = @userID
						  )

DECLARE @userCash MONEY = (SELECT Cash
							FROM UsersGames AS ug
							WHERE UserId = @userID
							  AND GameId = @gameID
					      )

DECLARE @itemsTotalAmount MONEY

BEGIN TRANSACTION
	SET @itemsTotalAmount = (SELECT SUM(Price)
								FROM Items
								WHERE MinLevel BETWEEN 11 AND 12)
	IF(@userCash >= @itemsTotalAmount)
		BEGIN
			INSERT INTO UserGameItems
				SELECT i.Id, @userGameID
					FROM Items AS i
					WHERE i.Id IN (SELECT id
							FROM Items 
							WHERE MinLevel BETWEEN 11 AND 12)
			UPDATE UsersGames
				SET Cash -= @itemsTotalAmount
				WHERE UserId = @userID
				 AND GameId = @gameID
			COMMIT
		END
	ELSE
		BEGIN
			ROLLBACK
		END
	SET @userCash = (SELECT Cash
						FROM UsersGames
						WHERE UserId = @userID
						  AND GameId = @gameID
				    )
BEGIN TRANSACTION
	SET @itemsTotalAmount = (SELECT SUM(Price)
								FROM Items
								WHERE MinLevel BETWEEN 19 AND 21)
	IF(@userCash >= @itemsTotalAmount)
		BEGIN
			INSERT INTO UserGameItems
			SELECT i.Id, @userGameID
				FROM Items AS i
				WHERE i.Id IN (SELECT Id
							FROM Items
							WHERE MinLevel BETWEEN 19 AND 21)
			UPDATE UsersGames
				SET Cash -= @itemsTotalAmount
				WHERE UserId = @userID
				 AND GameId = @gameID
			COMMIT
		END

	ELSE
		BEGIN
			ROLLBACK
		END
	SET @userCash = (SELECT Cash
						FROM UsersGames
						WHERE UserId = @userID
						  AND GameId = @gameID)

SELECT [Name]
	FROM Items
	WHERE id IN (SELECT	ItemId
					FROM UserGameItems
					WHERE UserGameId = @userGameID)

