USE master
GO

CREATE DATABASE WMS
GO

USE WMS
GO

CREATE TABLE Clients 
(
	ClientId INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics 
(
	MechanicId INT IDENTITY PRIMARY KEY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models 
(
	ModelId INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs 
(
	JobId INT IDENTITY PRIMARY KEY,
	ModelId INT FOREIGN KEY
				  REFERENCES Models(ModelId) 
				NOT NULL,
	[Status] CHAR(11) CHECK(LEN(Status) = 11
					    AND[Status] IN ('Pending',
										'In Progress' ,
										'Finished'))
					  DEFAULT 'Pending' 
					  NOT NULL,
	ClientId INT FOREIGN KEY
				   REFERENCES Clients(ClientId) 
				 NOT NULL,
	MechanicId INT FOREIGN KEY
				 REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders 
(
	OrderId INT IDENTITY PRIMARY KEY,
	JobId INT FOREIGN KEY
				REFERENCES Jobs(JobId) 
			  NOT NULL,
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors 
(
	VendorId INT IDENTITY PRIMARY KEY,
	[Name] VARCHAR(50) UNIQUE NOT NULL
)


CREATE TABLE Parts 
(
	PartId INT IDENTITY PRIMARY KEY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	[Description] VARCHAR(255),
	Price DECIMAL(6,2) CHECK(Price > 0) NOT NULL,
	VendorId INT FOREIGN KEY
				  REFERENCES Vendors(VendorId) 
				 NOT NULL,
	StockQty INT CHECK(StockQty >= 0) DEFAULT 0
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId) 
				NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) 
			   NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL
	CONSTRAINT PK_OrderParts
		PRIMARY KEY(OrderId, PartId)
)

CREATE TABLE PartsNeeded
(
	JobId INT FOREIGN KEY REFERENCES Orders(OrderId) 
				NOT NULL,
	PartId INT FOREIGN KEY REFERENCES Parts(PartId) 
			   NOT NULL,
	Quantity INT CHECK(Quantity > 0) DEFAULT 1 NOT NULL
	CONSTRAINT PK_PartsNeeded
		PRIMARY KEY(JobId, PartId)
)
