CREATE TABLE [dbo].[Region]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL,
	[UserId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Region_ToUser] FOREIGN KEY (UserId) REFERENCES [User](Id)
)
