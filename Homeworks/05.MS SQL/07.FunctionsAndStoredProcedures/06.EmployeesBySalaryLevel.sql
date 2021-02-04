USE SoftUni
GO

CREATE PROCEDURE usp_EmployeesBySalaryLevel(@LevelOfSalary VARCHAR(7))
AS
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
		FROM Employees

--Write a stored procedure usp_EmployeesBySalaryLevel that receive as parameter level of salary (low, average or high) and print the names of all employees that have given level of salary. You should use the function - "dbo.ufn_GetSalaryLevel(@Salary) ", which was part of the previous task, inside your "CREATE PROCEDURE …" query.