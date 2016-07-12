CREATE TABLE [dbo].[Pages]
(
	[PageId] INT NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(255) NOT NULL,
    [Slug] NVARCHAR(255) NOT NULL,
    [Content] NVARCHAR(MAX) NOT NULL,
    [IsActive] BIT NOT NULL ,
    [DisplayTitle] BIT NOT NULL ,
    [DateCreated] DATETIME NOT NULL ,
    [CreatedBy] INT NOT NULL ,
    [DateLastUpdated] DATETIME NULL,
    [LastUpdatedBy] INT NULL,
    CONSTRAINT [FK_Pages_Users-Created] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([UserId]),
    CONSTRAINT [FK_Pages_Users-LastUpdated] FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Users]([UserId])
)
