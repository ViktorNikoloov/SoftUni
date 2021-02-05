USE Bank
GO

CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountID INT, @Rate FLOAT)
AS
BEGIN
	DECLARE @Years INT = 5;

	SELECT a.Id AS [Account Id], 
		   ah.FirstName AS [First Name], 
		   ah.LastName AS [LastName], 
		   a.Balance AS [Current Balance], 
		   dbo.ufn_CalculateFutureValue(a.Balance, @Rate, @Years) AS [Balance in 5 years]
		FROM AccountHolders AS ah
		JOIN Accounts AS a ON a.Id = ah.Id
		WHERE a.Id = @AccountID
END
GO

EXEC usp_CalculateFutureValueForAccount 1, 0.1

select * FROM AccountHolders AS ac
		JOIN Accounts AS a ON ac.Id = a.Id
/*Your task is to create a stored procedure usp_CalculateFutureValueForAccount that uses the function from the previous problem to give an interest to a person's account for 5 years, along with information about his/her account id, first name, last name and current balance as it is shown in the example below. It should take the AccountId and the interest rate as parameters. Again you are provided with “dbo.ufn_CalculateFutureValue” function which was part of the previous task.*/