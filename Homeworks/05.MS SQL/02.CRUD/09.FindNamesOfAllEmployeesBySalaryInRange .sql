USE SoftUni
GO

SELECT FirstName, LastName, JobTitle
	FROM Employees
	WHERE Salary BETWEEN 20000 AND 30000

SELECT FirstName, LastName, JobTitle
	FROM Employees
	WHERE Salary >= 20000 AND Salary <= 30000

	