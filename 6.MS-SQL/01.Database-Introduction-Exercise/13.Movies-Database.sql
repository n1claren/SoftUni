CREATE TABLE Directors 
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(300)
)

CREATE TABLE Genres 
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(300)
)

CREATE TABLE Categories 
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) NOT NULL,
    [Notes] NVARCHAR(300)
)

CREATE TABLE [Movies] 
(
    [Id] INT PRIMARY KEY IDENTITY,
    [Title] NVARCHAR(50) NOT NULL,
    [DirectorId] INT FOREIGN KEY REFERENCES Directors(Id),
    [CopyrightYear] INT NOT NULL,
    [Length] TIME NOT NULL,
    [GenreId] INT FOREIGN KEY REFERENCES Genres(Id),
    [CategoryId]  INT FOREIGN KEY REFERENCES Categories(Id),
    [Rating] DECIMAL(3, 2) NOT NULL,
    [Notes] NVARCHAR(300)
)

INSERT INTO Directors ([Name], [Notes]) VALUES
('James Gunn', 'The Suicide Squad, fantastic movie'),
('Zack Snyder', 'Darkest DC Movies squad'),
('James Wan', 'Absolute legendary cinematography Aquaman'),
('Patty Jenkins', 'Wonder Woman movies'),
('David Ayer', 'not credited for his Suicide Squad')

INSERT INTO Categories([Name], [Notes]) VALUES
('Feature films', NULL),
('Historical films', NULL),
('Documentary films', NULL),
('Biographical films', NULL),
('Silent films', NULL)

INSERT INTO Genres ([Name], [Notes]) VALUES
('Action', NULL),
('Comedy', NULL),
('Fantasy', NULL),
('Mystery', NULL),
('Romance', NULL)

INSERT INTO Movies ([Title], [DirectorId], [CopyrightYear], [Length], [GenreId], [CategoryId], [Rating]) VALUES
('The Suicide Squad', 1, 2021, '2:12:00', 1, 1, 7.4),
('Zack Snyders Justice League', 2, 2020, '4:02:00', 1, 1, 8.1),
('Wonder Woman 1984', 4, 2020, '2:31:00', 1, 1, 5.4),
('Aquaman', 3, 2018, '2:23:00', 1, 1, 6.9),
('Suicide Squad', 5, 2016, '2:03:00', 1, 1, 5.9)