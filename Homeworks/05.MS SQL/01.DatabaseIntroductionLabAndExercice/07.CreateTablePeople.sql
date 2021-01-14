USE Minions

CREATE TABLE People
(
	Id BIGINT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(10, 2),
	[Weight] DECIMAL(10, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People([Name], Picture, Height, 
[Weight], Gender, Birthdate, Biography)
		VALUES
		('Viktor', NULL, 1.90, 90, 'm', '1992/10/28', 'Born in Plovdiv'),
		('Ivan', 'https://avatars3.githubusercontent.com/u/70409836?s=60&u=995427ad85d628d8a470666e2fde2424d3886b93&v=4', NULL, 75, 'm', '1996/04/05', 'Born in Plovdiv'),
		('Mariyan', NULL, 1.95, NULL, 'm', '1998/07/14', 'Born in Varna'),
		('Tanya', 'https://avatars3.githubusercontent.com/u/70409836?s=60&u=995427ad85d628d8a470666e2fde2424d3886b93&v=4', 1.84, 70, 'f', '1992/01/06', 'Born in Sofia'),
		('Ivana', NULL, 1.60, 55, 'f', '2002/12/12', NULL)