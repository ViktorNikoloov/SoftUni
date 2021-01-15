CREATE DATABASE CarRental 

USE CarRental

CREATE TABLE Categories 
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	DailyRate DECIMAL(2,1) NOT NULL,
	WeeklyRate DECIMAL(2,1) NOT NULL,
	MonthlyRate DECIMAL(2,1) NOT NULL,
	WeekendRate DECIMAL(2,1) NOT NULL,
)

INSERT Categories 
		VALUES
		('Minivan', 3.8, 5.6, 5.2, 4.8 ),
		('Sport', 6.8, 7.6, 4.3, 6.8 ),
		('Muscle', 5.8, 7.6, 9.1, 7.8 )

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY, 
	PlateNumber INT NOT NULL, 
	Manufacturer NVARCHAR(50) NOT NULL, 
	Model NVARCHAR(50) NOT NULL, 
	CarYear DATETIME NOT NULL, 
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id), 
	Doors INT, 
	Picture NVARCHAR(MAX), 
	Condition NVARCHAR(20), 
	Available BIT  NOT NULL
)

INSERT Cars(PlateNumber,Manufacturer,Model, CarYear,
CategoryId,Doors,Picture,Condition,Available) 
		VALUES
		(123456, 'Ford', 'Sharan', '1998.12.10', 1, 5, NULL, 'used', 1),
		(346363234, 'Audi', 'RS7', '2018.04.10', 2, Null, NULL, 'new', 1),
		(99988723, 'Mustang', 'GT', '2020.01.08', 3, 5, NULL, 'new', 0)
		
CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY, 
	FirstName NVARCHAR(20) NOT NULL, 
	LastName NVARCHAR(20) NOT NULL, 
	Title NVARCHAR(50), 
	Notes NVARCHAR(MAX)
)

INSERT Employees 
		VALUES
		('Viktor', 'Nikolov', 'Mr', NULL),
		('Stoyan', 'Stoyanov', 'Mr', NULL),
		('Georgi', 'Petrov', NULL, NULL)
		
CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY, 
	DriverLicenceNumber INT NOT NULL, 
	FullName NVARCHAR(50) NOT NULL, 
	[Address] NVARCHAR(70), 
	City NVARCHAR(20) NOT NULL, 
	ZIPCode INT NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT Customers 
		VALUES
		(84632002, 'Viktor Nikolov', 'Neva', 'Plovdiv', 4000, NULL),
		(13223545, 'Georgi Georgiev', NULL, 'Sofia', 54223, NULL),
		(84632002, 'Stoyan Stoyanov', NULL, 'Varna', 3850, NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY, 
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id), 
	CarId INT FOREIGN KEY REFERENCES Cars(Id), 
	TankLevel INT NOT NULL,
	KilometrageStart INT NOT NULL, 
	KilometrageEnd INT NOT NULL, 
	TotalKilometrage AS KilometrageEnd-KilometrageStart, 
	StartDate DATETIME NOT NULL, 
	EndDate DATETIME NOT NULL, 
	TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
	RateApplied DECIMAL(5,2), 
	TaxRate DECIMAL(10,2) NOT NULL, 
	OrderStatus NVARCHAR(50) NOT NULL, 
	Notes NVARCHAR(MAX)
)

INSERT RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,
KilometrageEnd,StartDate,EndDate,RateApplied,TaxRate,OrderStatus,Notes) 
		VALUES
		(1,1,1,70, 25, 200, '2020/05/12', '2020/05/25', NULL, 200.45, 'apply', NULL),										   
		(2,2,2,60, 15, 156, '2020/05/05', '2020/05/15', 125.758, 500.45, 'Complete', NULL),										  
		(3,3,3,50, 36, 100, '2020/05/20', '2020/05/28', NULL, 625.45, 'NotComplete', NULL)

