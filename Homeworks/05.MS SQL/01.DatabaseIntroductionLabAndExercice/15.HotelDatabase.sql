CREATE DATABASE Hotel
GO

USE Hotel
GO

CREATE TABLE Employees 
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	Title NVARCHAR(30) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Employees
		VALUES
		('Viktor', 'Nikolov', 'Restaurant Manager', NULL),
		('Mariyan', 'Ivanov', 'Head Chef', NULL),
		('Ivan', 'Georgiev', 'Hotel Porter', NULL)

CREATE TABLE Customers  
(
	AccountNumber NVARCHAR(20) PRIMARY KEY, 
	FirstName NVARCHAR(30) NOT NULL, 
	LastName NVARCHAR(30) NOT NULL, 
	PhoneNumber VARCHAR(10) NOT NULL, 
	EmergencyName VARCHAR(30) NOT NULL, 
	EmergencyNumber VARCHAR(10) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Customers
		VALUES
		('1123213', 'Viktor', 'Nikolov', '0886278394', 'Tanya Petkova', '0887438291', NULL),
		('2652625', 'Mariyan', 'Ivanov', '0886278394', 'Tanya Damqnova', '0887536273', NULL),
		('9680464', 'Ivan', 'Georgiev', '0886278394', 'Petya Todorova', '0888637261', NULL)

CREATE TABLE RoomStatus 
(
	RoomStatus NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomStatus
		VALUES
		('Reserved', NULL),
		('Free', NULL),
		('Not Available', NULL)

CREATE TABLE RoomTypes  
(
	RoomType NVARCHAR(15) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO RoomTypes
		VALUES
		('Single', NULL),
		('Double', NULL),
		('Triple', NULL)

CREATE TABLE BedTypes   
(
	BedType NVARCHAR(20) PRIMARY KEY NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO BedTypes
		VALUES
		('One Person', NULL),
		('Two Persons', NULL),
		('Three Persons', NULL)

CREATE TABLE Rooms 
(
	RoomNumber INT PRIMARY KEY IDENTITY,
	RoomType NVARCHAR(15) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	BedType NVARCHAR(20) FOREIGN KEY REFERENCES BedTypes(BedType),
	Rate DECIMAL(2,1),
	RoomStatus NVARCHAR(20) FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
	Notes NVARCHAR(MAX)
)

INSERT Rooms
		VALUES
		('Single', 'One Person', NULL, 'Reserved', NULL),
		('Double', 'Two Persons', 5.8, 'Free',NULL),
		('Triple', 'Three Persons', 4.5, 'Not Available', NULL)

CREATE TABLE Payments 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	PaymentDate DATETIME NOT NULL, 
	AccountNumber NVARCHAR(20) FOREIGN KEY REFERENCES Customers(AccountNumber), 
	FirstDateOccupied DATETIME NOT NULL, 
	LastDateOccupied DATETIME NOT NULL, 
	TotalDays AS DATEDIFF(DAY,FirstDateOccupied,LastDateOccupied), 
	AmountCharged DECIMAL(6,2) NOT NULL, 
	TaxRate DECIMAL(5,2) NOT NULL, 
	TaxAmount AS AmountCharged * TaxRate, 
	PaymentTotal DECIMAL(8,2) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT INTO Payments(EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, 
LastDateOccupied, AmountCharged, TaxRate, PaymentTotal, Notes)
		VALUES
		(1, '2020/04/12', '1123213', '2020/04/01', '2020/04/12', 400.43, 30.12, 700.54, NULL),
		(2, '2020/07/25', '2652625', '2020/04/10', '2020/04/25', 254.43, 15.12, 500.54, NULL),
		(3, '2020/09/18', '9680464', '2020/04/15', '2020/04/18', 180.43, 9.12, 300.54, NULL)

CREATE TABLE Occupancies 
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	DateOccupied DATETIME NOT NULL, 
	AccountNumber NVARCHAR(20) FOREIGN KEY REFERENCES Customers(AccountNumber), 
	RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber), 
	RateApplied DECIMAL(2,1), 
	PhoneCharge DECIMAL(7,3), 
	Notes NVARCHAR(MAX)
)

INSERT INTO Occupancies
		VALUES
		(1, '2020.01.20', '1123213', 1, 5.5, 200.83, NULL),
		(2, '2020.10.10', '2652625', 2, 7.1, 158.55, NULL),
		(3, '2020.01.20', '9680464', 3, 4.6, 111.27, NULL)