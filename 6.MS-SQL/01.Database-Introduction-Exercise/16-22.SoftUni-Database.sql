-- 16.Create-SoftUni-Database 

CREATE DATABASE SoftUni

CREATE TABLE Towns
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
)

CREATE TABLE Addresses
(
	[Id] INT PRIMARY KEY IDENTITY,
	[AddressText] NVARCHAR(50) NOT NULL,
	[TownId] INT FOREIGN KEY REFERENCES Towns(Id)
)

CREATE TABLE Departments
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(20) NOT NULL,
)

CREATE TABLE Employees
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] NVARCHAR(20) NOT NULL,
	[MiddleName] NVARCHAR(20) NOT NULL,
	[LastName] NVARCHAR(20) NOT NULL,
	[JobTitle] NVARCHAR(20) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES Departments(Id),
	[HireDate] DATE NOT NULL,
	[Salary] DECIMAL(7, 2) NOT NULL,
	[AddressId] INT FOREIGN KEY REFERENCES Addresses(Id)
) 

-- 18.Basic-Insert 

INSERT INTO Towns ([Name]) VALUES 
('Varna'),
('Plovdiv'),
('Sofia'),
('Burgas')

INSERT INTO Departments ([Name]) VALUES 
('Marketing'),
('Sales'),
('Engineering'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees ([FirstName], [MiddleName], [LastName], [JobTitle], [DepartmentId], [HireDate], [Salary]) VALUES 
('Dragan' , 'Draganov' , 'Draganov', 'Senior Engineer', 1, '2004/02/03', 14027.21),
('Georgi' , 'Georgiev' , 'Georgiev', 'Sales Manager', 2, '2007/09/10', 3500.69),
('Ivana' , 'Ivanova' , 'Ivanova', 'Quality Assurance', 5, '2016/08/08', 1525.22),
('Petkan' , 'Petkanov' , 'Petkov', 'Marketing', 3, '2016/11/11', 1599.88)

-- 19.Basic-Select-All-Fields

SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

-- 20.Basic-Select-All-Fields-And-Order-Them

SELECT * FROM Towns ORDER BY [Name] ASC

SELECT * FROM Departments ORDER BY [Name] ASC

SELECT * FROM Employees ORDER BY [Salary] DESC

-- 21.Basic-Select-Some-Fields

SELECT [Name] FROM Towns ORDER BY [Name] ASC

SELECT [Name] FROM Departments ORDER BY [Name] ASC

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees ORDER BY [Salary] DESC

-- 22.Increase-Employees-Salary

UPDATE Employees SET Salary += Salary * 0.15

SELECT Salary FROM Employees