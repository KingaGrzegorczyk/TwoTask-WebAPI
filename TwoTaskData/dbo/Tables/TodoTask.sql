﻿CREATE TABLE [dbo].[TodoTask]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [ListId] INT NOT NULL, 
    [BeginDate] DATETIME2 NOT NULL DEFAULT getutcdate(), 
    [EndDate] DATETIME2 NULL, 
    [RegionId] INT NOT NULL, 
    [Description] NVARCHAR(150) NULL, 
    [Title] NVARCHAR(50) NOT NULL, 
    [Priority] INT NOT NULL DEFAULT 0, 
    [Status] NVARCHAR(50) NOT NULL, 
    [UserId] NVARCHAR(128) NOT NULL
)