USE SoftUni
GO

CREATE FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
RETURNS VARCHAR(7)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(7)
	IF(@Salary < 30000)
		SET @SalaryLevel = 'Low';
	ELSE 
		IF(@Salary < 30000)
			SET @SalaryLevel = 'Low';
	ELSE 
		IF(@Salary BETWEEN 30000 AND 50000)
			SET @SalaryLevel = 'Average';
		ELSE 
			SET @SalaryLevel = 'High'
	RETURN @SalaryLevel
END
GO

SELECT Salary, 
	   dbo.ufn_GetSalaryLevel (Salary) AS [Salary Level]
	FROM Employees
