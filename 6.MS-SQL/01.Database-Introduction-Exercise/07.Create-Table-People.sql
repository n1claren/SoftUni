CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	Picture VARBINARY(2),
	Height DECIMAL(3, 2),
	[Weight] DECIMAL(5, 2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES	
('Pesho Djumerkata', NULL, 1.51, 69.69, 'M', '1989-06-22', 'Loves Djumerki'),
('Kalin Satelita', NULL, 1.75, 122.88, 'M', '1999-01-01', 'never pays full poker entry, only satellite' ),
('Ivan Basher', NULL, 1.74, 74.47, 'M', '1995-12-25', 'dota2 noob from russia, basher on every hero' ),
('Zlatina Balewa', NULL, 1.56, 52.60, 'F', '1988-12-04', 'now goes by husbands name Karshanova' ),
('Stilian Enev', NULL, 1.79, 95.50, 'M', '1989-05-20', 'batshit crazy, kind of alcoholic')