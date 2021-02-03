USE SoftUni
GO

CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber (@Salary DECIMAL(18,4))
AS	
BEGIN
	SELECT FirstName AS [First Name], LastName AS [Last Name]
	FROM Employees
	WHERE Salary >= @Salary
END
GO

EXEC usp_GetEmployeesSalaryAboveNumber 48100





--Create stored procedure usp_GetEmployeesSalaryAboveNumber that accept a number (of type DECIMAL(18,4)) as parameter and returns all employees’ first and last names whose salary is above or equal to the given number. 