CREATE TABLE Categories
(
	[Id] INT PRIMARY KEY IDENTITY,
	[CategoryName] NVARCHAR(50) NOT NULL,
	[DailyRate] DECIMAL(6, 2) NOT NULL,
	[WeeklyRate] DECIMAL(8, 2) NOT NULL,
	[MonthlyRate] DECIMAL(10, 2) NOT NULL,
	[WeekendRate] DECIMAL(6, 2) NOT NULL
)

CREATE TABLE Cars
(
	[Id] INT PRIMARY KEY IDENTITY,
	[NumberPlate] NVARCHAR(10) NOT NULL,
	[Manufacturer] NVARCHAR(30) NOT NULL,
	[Model] NVARCHAR(30) NOT NULL,
	[Year] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories(Id),
	[Doors] INT NOT NULL,
	[Picture] NVARCHAR(300),
	[Condition] NVARCHAR(30),
	[Available] BIT NOT NULL,
)

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[Title] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(300)
)

CREATE TABLE Customers
(
	[Id] INT PRIMARY KEY IDENTITY,
	[DriverLicenceNumber] NVARCHAR(10) NOT NULL,
	[FullName] NVARCHAR(30) NOT NULL,
	[Address] NVARCHAR(30),
	[City] NVARCHAR(30) NOT NULL,
	[ZIPCode] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(300)
)

CREATE TABLE [RentalOrders]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees(Id),
	[CustomerId] INT FOREIGN KEY REFERENCES Customers(Id),
	[CarId] INT FOREIGN KEY REFERENCES Cars(Id),
	[TankLevel] INT NOT NULL,
	[KilometrageStart] INT NOT NULL,
	[KilometrageEnd] INT NOT NULL,
	[TotalKilometrage] AS [KilometrageStart] - [KilometrageEnd],
	[StartDate] DATETIME NOT NULL,
	[EndDate] DATETIME NOT NULL,
	[TotalDate] AS DATEDIFF(Day, [StartDate], [EndDate]),
	[RateApplied] DECIMAL(5, 2) NOT NULL,
	[TaxRate] DECIMAL(7, 2) NOT NULL,
	[OrderStatus] NVARCHAR(30) NOT NULL,
	[Notes] NVARCHAR(300)
)

INSERT INTO Categories ([CategoryName], [DailyRate], [WeeklyRate], [MonthlyRate], [WeekendRate]) VALUES 
('Coupe', 249.99, 2200, 7000, 156.25),
('Hatchback', 199.99, 1800, 6000, 100.25),
('Bus', 99.99, 80, 4000, 56.25)

INSERT INTO Cars ([NumberPlate], [Manufacturer], [Model], [Year], [CategoryId], [Doors], [Picture], [Condition], [Available]) VALUES 
('Â8813ÀÕ', 'BMW', 'BMW M3', 2008, 1, 4, NULL, 'Used', 1),
('Í2366ÃÕ', 'Audi', 'RS6', 2017, 2, 4, NULL, 'Used', 0),
('ÑÀ5354ÕÑ', 'Mercedes', 'SLR500', 2011, 3, 4, NULL, 'Used', 1)

INSERT INTO Employees ([FirstName], [LastName], [Title]) VALUES 
('Henry', 'Cavill', 'Manager'),
('Ben', 'Affleck', 'Manager'),
('Gal','Gadot', 'Supervisor')

INSERT INTO Customers ([DriverLicenceNumber], [FullName], [Address], [City], [ZIPCode]) VALUES 
('10203040', 'Nikolay Yanev Ivanov', 'Kaisieva Gradina 215', 'Varna', '9023'),
('40302010', 'Rumiana Mihailova Ivanova', 'Kaisieva Gradina 215', 'Varna', '9023'),
('12345678', 'James Deen', 'Malibu beach 69', 'Los Angeles', '696969')

INSERT INTO RentalOrders ([EmployeeId], [CustomerId], [CarId], [TankLevel], [KilometrageStart], [KilometrageEnd], [StartDate], [EndDate], [RateApplied], [TaxRate], [OrderStatus]) VALUES 
(1, 1, 1, 7, 600, 900, '2020-08-04', '2020-08-06', 69.99, 15.00, 'True'),
(2, 2, 2, 7, 600, 900, '2020-08-04', '2020-08-06', 89.99, 15.00, 'False'),
(3, 3, 3, 7, 600, 900, '2020-08-04', '2020-08-06', 99.99, 15.00, 'True')