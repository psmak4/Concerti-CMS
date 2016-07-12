CREATE TABLE [dbo].[SettingOptions]
(
	[SettingOptionId] INT NOT NULL PRIMARY KEY,
    [SettingId] INT NOT NULL,
    [Text] NVARCHAR(MAX) NOT NULL,
    [Value] NVARCHAR(MAX) NOT NULL,
    CONSTRAINT [FK_SettingOptions_Settings] FOREIGN KEY ([SettingId]) REFERENCES [Settings]([SettingId])
)
