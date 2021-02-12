USE SoftUni
GO

CREATE TABLE Deleted_Employees
(EmployeeId INT IDENTITY,
 FirstName VARCHAR(50), 
 LastName VARCHAR(50), 
 MiddleName VARCHAR(50), 
 JobTitle VARCHAR(50), 
 DepartmentId INT, 
 Salary MONEY
 
 CONSTRAINT PK_Deleted_Employees_Id
 PRIMARY KEY(EmployeeId))
 GO

 CREATE TRIGGER tr_AddDeleted
 ON Employees
 AFTER DELETE
 AS
 BEGIN
	INSERT INTO Deleted_Employees(FirstName,LastName,MiddleName,JobTitle,DepartmentId,Salary)
	SELECT FirstName,LastName,MiddleName,JobTitle,DepartmentID,Salary
	FROM deleted
 END
 GO

 SELECT * FROM Deleted_Employees