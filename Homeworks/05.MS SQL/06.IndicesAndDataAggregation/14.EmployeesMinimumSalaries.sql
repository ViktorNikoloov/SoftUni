USE SoftUni
GO

SELECT DepartmentID, MIN(Salary)
	FROM Employees
	WHERE DepartmentID IN (2, 5, 7)
	  AND HireDate > '2000/01/01'
	  GROUP BY DepartmentID