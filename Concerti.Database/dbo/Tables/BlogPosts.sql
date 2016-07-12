CREATE TABLE [dbo].[BlogPosts]
(
	[BlogPostId] INT NOT NULL PRIMARY KEY,
    [Title] NVARCHAR(255) NOT NULL,
    [Slug] NVARCHAR(255) NOT NULL,
    [Content] NVARCHAR(MAX) NOT NULL,
    [AllowComments] BIT NOT NULL ,
    [IsPublished] BIT NOT NULL ,
    [DateCreated] DATETIME NOT NULL ,
    [CreatedBy] INT NOT NULL ,
    [DateLastUpdated] DATETIME NULL,
    [LastUpdatedBy] INT NULL, 
    CONSTRAINT [FK_BlogPosts_Users-Created] FOREIGN KEY ([CreatedBy]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_BlogPosts_Users-LastUpdated] FOREIGN KEY ([LastUpdatedBy]) REFERENCES [Users]([UserId])
)
