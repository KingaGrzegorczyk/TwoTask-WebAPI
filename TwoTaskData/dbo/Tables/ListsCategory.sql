﻿CREATE TABLE [dbo].[ListsCategory]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [CategoryId] INT NOT NULL DEFAULT 0
)
