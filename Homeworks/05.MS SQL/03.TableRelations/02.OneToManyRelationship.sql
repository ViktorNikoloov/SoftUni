CREATE TABLE Manufacturers
(
	ManufacturerID INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(30) NOT NULL,
	EstablishedOn DATE NOT NULL
)

INSERT INTO Manufacturers 
	VALUES
	('BMW', '1916/03/07'),
	('Tesla', '2003/01/01'),
	('Lada', '1966/05/01')

CREATE TABLE Models
(
	ModelID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] VARCHAR(20),
	ManufacturerID INT NOT NULL 
	FOREIGN KEY REFERENCES Manufacturers(ManufacturerID)
)

INSERT INTO Models([Name], ManufacturerID) 
	VALUES
	('X1', 1),
	('i6', 1),
	('Model S', 2),
	('Model X', 2),
	('Model 3', 2),
	('Nova', 3)