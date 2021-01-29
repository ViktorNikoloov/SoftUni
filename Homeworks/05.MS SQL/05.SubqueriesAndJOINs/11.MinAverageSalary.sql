USE SoftUni
GO

SELECT MIN([Average Salary]) AS [MinAverageSalary]
	FROM (
		  SELECT DepartmentID, AVG(Salary)AS [Average Salary]
		  FROM Employees
		  GROUP BY DepartmentID
		 ) AS [AverageQuery]

SELECT TOP(1) AVG(Salary) AS [MinAverageSalary]
	FROM Employees
	GROUP BY DepartmentID
	ORDER BY [MinAverageSalary] ASC