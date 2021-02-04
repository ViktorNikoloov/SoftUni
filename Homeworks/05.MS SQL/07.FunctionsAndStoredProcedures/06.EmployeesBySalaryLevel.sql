USE SoftUni
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(7))
AS
BEGIN
	SELECT [EmployeesInfo].[First Name], [EmployeesInfo].[Last Name]
		FROM (
			  SELECT FirstName AS [First Name], 
				     LastName AS [Last Name], 
				     dbo.ufn_GetSalaryLevel (Salary) AS [SalaryLevel]
		      FROM Employees
		     ) AS [EmployeesInfo]
		WHERE @LevelOfSalary = [SalaryLevel]
END
GO

EXEC usp_EmployeesBySalaryLevel 'High'
GO

/*SecondSolution*/
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(7))
AS
BEGIN
	SELECT FirstName AS [First Name], 
		   LastName AS [Last Name]
	FROM Employees
	WHERE @LevelOfSalary = dbo.ufn_GetSalaryLevel(Salary)
END
GO

EXEC usp_EmployeesBySalaryLevel 'High'