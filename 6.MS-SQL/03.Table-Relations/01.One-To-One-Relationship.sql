CREATE TABLE Persons
(
	PersonID INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(30) NOT NULL,
	Salary DECIMAl(8, 2) NOT NULL,
	PassportID INT NOT NULL
)

INSERT INTO Persons	(FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

CREATE TABLE Passports
(
	PassportID INT IDENTITY(101, 1) PRIMARY KEY,
	PassportNumber CHAR(8)
)

INSERT INTO Passports (PassportNumber) VALUES
('N34FG21B'),
('K65LO4R7'),
('ZE657QP2')

ALTER TABLE Persons
	ADD CONSTRAINT FK_PersonsPassports
	FOREIGN KEY (PassportID) REFERENCES Passports(PassportID)