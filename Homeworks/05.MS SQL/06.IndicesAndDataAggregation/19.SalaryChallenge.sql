USE SoftUni
GO

SELECT TOP(10) e.FirstName, e.LastName,[AVGSalaryQuery].DepartmentID
	FROM(
		 SELECT DepartmentID, AVG(Salary) AS [Department's Average Salary]
		 FROM Employees
		 GROUP BY DepartmentID 
		) AS [AVGSalaryQuery]
	JOIN Employees AS e ON e.DepartmentID = [AVGSalaryQuery].DepartmentID
WHERE Salary > [Department's Average Salary]
ORDER BY DepartmentID
