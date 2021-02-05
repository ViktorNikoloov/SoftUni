USE Diablo
GO

CREATE FUNCTION ufn_CashInUsersGames(@NameOfTheGame NVARCHAR(50))
RETURNS TABLE
AS
RETURN
	SELECT SUM(Cash) AS [SumCash]
		FROM (
			  SELECT ug.Cash,
					 ROW_NUMBER() 
						OVER (ORDER BY ug.Cash DESC ) AS [RowsRanking]
			  FROM Games AS g
			  JOIN UsersGames AS ug ON ug.GameId = g.Id
			  WHERE g.[Name] = @NameOfTheGame
			 ) AS [RowsRankingQuery]
		WHERE [RowsRanking] % 2 = 1
GO

SELECT *
	FROM [dbo].[ufn_CashInUsersGames] ('Love in a mist')