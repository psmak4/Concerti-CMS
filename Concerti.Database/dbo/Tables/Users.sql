CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [Email] NVARCHAR(MAX) NOT NULL, 
    [EmailConfirmed] BIT NOT NULL, 
    [Username] NVARCHAR(MAX) NOT NULL, 
    [Password] NVARCHAR(MAX) NOT NULL, 
    [FirstName] NVARCHAR(100) NULL, 
    [LastName] NVARCHAR(100) NULL, 
    [DateCreated] DATETIME NOT NULL, 
    [IsActive] BIT NOT NULL 
)
