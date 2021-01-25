USE SoftUni
GO

CREATE VIEW V_EmployeesHiredAfter2000 
	AS
	SELECT FirstName, LastName, HireDate
		FROM Employees
		WHERE YEAR(HireDate) BETWEEN 2001 AND GETDATE()
		--WHERE YEAR(HireDate) > 2000