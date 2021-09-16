-- CREATE DATABASE Hotel
-- USE Hotel

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(300)
)

CREATE TABLE Customers
(
	[AccountNumber] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[PhoneNumber] NVARCHAR(10) NOT NULL,
	[EmergencyName] NVARCHAR(20) NOT NULL,
	[EmergencyNumber] NVARCHAR(10) NOT NULL,
	[Notes] NVARCHAR (300)
)

CREATE TABLE RoomStatus
(
	[RoomStatus] NVARCHAR(10) PRIMARY KEY,
	[Notes] NVARCHAR(300)
)

CREATE TABLE RoomTypes 
(
	[RoomType] NVARCHAR(10) PRIMARY KEY,
	[Notes] NVARCHAR(300)
)

CREATE TABLE BedTypes
(
	[BedType] NVARCHAR(10) PRIMARY KEY,
	[Notes] NVARCHAR(300)
)

CREATE TABLE Rooms
(
	[RoomNumber] INT PRIMARY KEY IDENTITY,
	[RoomType] NVARCHAR(10) FOREIGN KEY REFERENCES RoomTypes(RoomType),
	[BedType] NVARCHAR(10) FOREIGN KEY REFERENCES BedTypes(BedType),
	[Rate] DECIMAL(5, 2) NOT NULL,
	[RoomStatus] NVARCHAR(20) NOT NULL,
	[Notes] NVARCHAR(300)
)

CREATE TABLE Payments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[PaymentDate] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	[FirstDateOccupied] DATETIME2 NOT NULL,
	[LastDateOccupied] DATETIME2 NOT NULL,
	[TotalDays] AS DATEDIFF(DAY, FirstDateOccupied, LastDateOccupied),
	[AmountCharged] DECIMAL(6, 2) NOT NULL,
	[TaxRate] DECIMAL(5, 2) NOT NULL,
	[TaxAmount] AS AmountCharged * TaxRate,
	[PaymentTotal] DECIMAL(6,2) NOT NULL,
	[NOTES] NVARCHAR(300)
)

CREATE TABLE Occupancies
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[DateOccupied] DATETIME2 NOT NULL,
	[AccountNumber] INT FOREIGN KEY REFERENCES Customers(AccountNumber),
	[RoomNumber] INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
	[RateApplied] DECIMAL(5, 2), 
	[PhoneCharge] DECIMAL(5, 2),
	[Notes] NVARCHAR(300)
)

INSERT INTO Employees([FirstName], [LastName], [Title]) VALUES
('Henry', 'Cavill', 'Programmer'),
('Ben', 'Affleck', 'Physicist'),
('Gal', 'Gadot', 'Biologist')

INSERT INTO Customers ([FirstName], [LastName], [PhoneNumber], [EmergencyName], [EmergencyNumber]) VALUES
('Asan', 'Ahmedov', '0888855441', 'Mangoto', '0888885261'),
('Ivan', 'Bashera', '0878588611', 'Dotadjiqta', '0877698412'),
('Ivanka', 'Dashnata', '0879476524', 'Kvartalnata kovra', '0879476524')

INSERT INTO RoomStatus ([RoomStatus]) VALUES
('Free'),
('Taken'),
('Must be cleaned')

INSERT INTO RoomTypes ([RoomType]) VALUES
('Single'),
('Double'),
('Family')

INSERT INTO BedTypes ([BedType]) VALUES
('Single'),
('Double'),
('Orgy')

INSERT INTO Rooms ([RoomType], [BedType], [Rate], [RoomStatus]) VALUES
('Single', 'Single', 29.99, 'Closed'),
('Double', 'Double', 49.99, 'Closed'),
('Family', 'Double', 89.99, 'Closed')

INSERT INTO Payments ([PaymentDate], [AccountNumber], [FirstDateOccupied], [LastDateOccupied], [AmountCharged], [TaxRate], [PaymentTotal]) VALUES
('2020-05-10','1','2021-05-10','2021-05-25', 240, 20, 720),
('2020-06-10','2','2021-06-10','2021-06-25', 1240, 20, 720),
('2020-07-10','3','2021-07-10','2021-07-25', 1440, 20, 720) 

INSERT INTO Occupancies ([DateOccupied], [AccountNumber], [RoomNumber], [RateApplied], [PhoneCharge]) VALUES
('2020-05-10', 1, 1, 55.5, 5),
('2020-06-10', 2, 2, 55.5, 5),
('2020-07-10', 3, 3, 55.5, 5)