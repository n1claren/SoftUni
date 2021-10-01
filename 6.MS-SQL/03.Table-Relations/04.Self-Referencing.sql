CREATE TABLE Teachers
(
	TeacherID INT IDENTITY(101, 1) PRIMARY KEY,
	[Name] VARCHAR(20) NOT NULL,
	ManagerID INT,
    CONSTRAINT FK_ManagerTeacher FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)
)

INSERT INTO Teachers([Name], ManagerID) VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)