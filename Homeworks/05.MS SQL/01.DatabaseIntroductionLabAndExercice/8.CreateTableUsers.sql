CREATE TABLE Users
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) UNIQUE NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX)
	CHECK(DATALENGTH(ProfilEPicture)<= 900*1024),
	LastLoginTime DATETIME NOT NULL,
	IsDeleted BIT NOT NULL
)

INSERT Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted)
		VALUES
		('Viktor', '123456', NULL, '05.15.2017', 0),
		('Ivan', '463252523', NULL, '12.01.2021', 1),
		('Stoyan', 'asgd3', NULL, '07.12.2020', 0),
		('Angel', 'hyjesf', NULL, '11.29.2016', 1),
		('Mariya', 'asdfgh', NULL, '02.23.2019', 0)
