﻿CREATE TABLE [dbo].[Group]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(30) NOT NULL, 
    [OwnerId] UNIQUEIDENTIFIER NOT NULL, 
    CONSTRAINT [FK_Group_ToUser] FOREIGN KEY (OwnerId) REFERENCES [User]([Id])
)
