CREATE TABLE [dbo].[UserRoles]
(
	[UserId] INT NOT NULL , 
    [RoleId] INT NOT NULL, 
    CONSTRAINT [FK_UserRoles_Users] FOREIGN KEY ([UserId]) REFERENCES [Users]([UserId]), 
    CONSTRAINT [FK_UserRoles_Roles] FOREIGN KEY ([RoleId]) REFERENCES [Roles]([RoleId])
)
