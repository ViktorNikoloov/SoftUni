CREATE DATABASE Movies
GO

Use Movies
GO

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors VALUES
('Viktor', 'CTO' ),
('Mariyan', NULL ),
('Stoyan', NULL ),
('Tanya', NULL ),
('Mariya', 'Live in Plovdiv' )

CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Genres 
		VALUES
		('Military fiction', NULL ),
		('Comic fantasy', NULL ),
		('Black comedy ', NULL ),
		('Gangster', NULL ),
		('Horror', 'Children under the age of 12 are not permitted' )

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName NVARCHAR(50) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories 
		VALUES
		('Action', NULL ),
		('Adventure', NULL ),
		('Crime', NULL ),
		('Comedy', NULL ),
		('Horror', 'Children under the age of 12 are not permitted' )

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(50) NOT NULL,
	DirectorID INT FOREIGN KEY REFERENCES Directors(Id),
	CopyrightYear DATETIME NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES GenreS(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL (2,1) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO  Movies(Title, CopyrightYear, Length, Rating, Notes) 
		VALUES
		('Three Days of the Condor', '1987/07/18', 120, 8.9, NULL),
		('Kill Bill', '1992/10/12', 150, 7.0, NULL ),
		('They Shoot Horses, Dont They', '1997/12/12', 90, 8.2, NULL ),
		('The Place Beyond the Pines', '1996/01/08', 135, 5.3, NULL ),
		('Bang the Drum Slowly', '2001/10/12', 68, 6.7, NULL)

