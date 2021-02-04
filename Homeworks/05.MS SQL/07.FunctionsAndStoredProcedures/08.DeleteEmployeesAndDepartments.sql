USE SoftUni
GO

CREATE PROCEDURE usp_DeleteEmployeesFromDepartment(@DepartmentId INT)
AS
BEGIN
	--Delete all records from EmployeesProjects where EmployeeId is going to be deleted
	DELETE
		FROM EmployeesProjects
		WHERE EmployeeID IN	(
							 SELECT EmployeeID
							 FROM Employees
							 WHERE DepartmentID = @DepartmentId
						    )

    --Set ManagerId to null where Manager is an Employee who is going to be deleted
	UPDATE Employees
		SET ManagerID = NULL
		WHERE EmployeeID IN (
							 SELECT EmployeeID
							 FROM Employees
							 WHERE DepartmentID = @DepartmentId
							)

	--Set ManagerID column in Departments table to nullable 
	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
		SET ManagerID = NULL
		WHERE ManagerID IN (
							SELECT ManagerID
							FROM Employees
							WHERE DepartmentID = @DepartmentId
						   )

	--Deletes all Employees from a given department				
	DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

	DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId

	SELECT COUNT(*)
		FROM Employees
		WHERE DepartmentID = @DepartmentId

END
GO