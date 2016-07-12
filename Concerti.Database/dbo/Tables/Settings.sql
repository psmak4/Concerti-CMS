CREATE TABLE [dbo].[Settings]
(
	[SettingId] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(255) NOT NULL, 
    [Value] NVARCHAR(MAX) NOT NULL
)
