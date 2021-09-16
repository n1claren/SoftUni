CREATE TABLE Users
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	[ProfilePicture] VARCHAR(MAX),
	[LastLoginTime] DATETIME,
	[IsDeleted] BIT DEFAULT 'false'
)

INSERT INTO Users 
(Username, [Password], [ProfilePicture], [LastLoginTime], [IsDeleted]) 
VALUES
('n1claren', 'NotMyRealPassword123', 'randompicturelink.com/image.jpg', '2021-09-16', 0),
('kalz3hardy', 'NotHisRealPassword123', 'randompicturelink.com/image.jpg', '2021-09-14', 0),
('dotasmurf', 'NotHisRealPassword123', 'randompicturelink.com/image.jpg', '2019-08-08', 1),
('apexPlayer', 'NotHisRealPassword123', 'randompicturelink.com/image.jpg', '2021-07-26', 1),
('LittleD', 'NotHerRealPassword123', 'randompicturelink.com/image.jpg', '2020-11-30', 0)

ALTER TABLE Users
DROP CONSTRAINT PK__Users_3214EC076E334BA7

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY ([Id], [Username])

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeastFiveSymbols CHECK (LEN([Password])>=5)

ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR [LastLoginTime]