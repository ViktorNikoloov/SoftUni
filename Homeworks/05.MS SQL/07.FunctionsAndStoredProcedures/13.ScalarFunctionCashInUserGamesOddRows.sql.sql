USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@NameOfTheGame NVARCHAR(50))
RETURNS DECIMAL(18,2)
AS
BEGIN
	SELECT ROW_NUMBER()
			OVER (ORDER BY ug.Cash DESC ) AS [RowsRanking], 
		ug.Cash
		FROM Games AS g
		JOIN UsersGames AS ug ON ug.GameId = g.Id
		WHERE g.[Name] = 'Love in a mist'--@NameOfTheGame
END
GO

SELECT Name
		FROM Games
		WHERE Name LIKE ('LOVE%')
		ORDER BY 
--that sums the cash of odd rows. Rows must be ordered by cash in descending order. The function should take a game name as a parameter and return the result as table. Submit only your function in.
--Execute the function over the following game names, ordered exactly like: "Love in a mist".
