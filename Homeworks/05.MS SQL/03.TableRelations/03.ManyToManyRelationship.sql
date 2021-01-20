CREATE TABLE Students
(
	StudentID INT IDENTITY PRIMARY KEY,
	[Name] NVARCHAR(50)
)

INSERT INTO Students 
	VALUES
	('Mila'),
	('Toni'),
	('Ron')

CREATE TABLE Exams
(
	ExamID INT IDENTITY(101,1) PRIMARY KEY,
	[Name] NVARCHAR(50)
)

INSERT INTO Exams 
	VALUES
	('SpringMVC'),
	('Neo4j'),
	('Oracle 11g')

CREATE TABLE StudentsExams
(
	StudentID INT NOT NULL
	FOREIGN KEY REFERENCES Students(StudentID),
	ExamID INT NOT NULL
	FOREIGN KEY REFERENCES Exams(ExamID)
	CONSTRAINT PK_StudentsExams
	PRIMARY KEY(StudentID, ExamID)
)
