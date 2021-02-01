USE SoftUni
GO

SELECT DISTINCT DepartmentID, Salary AS [ThirdHighestSalary]
	FROM
		(SELECT DepartmentID,
				Salary,
				DENSE_RANK() 
					OVER(
						 PARTITION BY DepartmentID 
						 ORDER BY Salary DESC
						) AS [SalaryRank]
		FROM Employees) AS [RankQuery]
WHERE[SalaryRank] = 3

/*SecondSolution*/
SELECT DepartmentID, MaxSalary
	FROM (
		  SELECT e.DepartmentID,
				 MAX(e.Salary) AS MaxSalary,
				 DENSE_RANK()
					OVER (
						  PARTITION BY DepartmentID 
						  ORDER BY e.Salary DESC
						 ) AS [SalaryRank]
		  FROM Employees AS e
		  GROUP BY e.DepartmentID, e.Salary
		 ) AS [RankQuery]
WHERE [SalaryRank] = 3